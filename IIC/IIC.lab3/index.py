import numpy as np
import matplotlib.pyplot as plt

# Кількість рук, які можна обрати
num_actions = 10

# Функція для генерації нагороди для конкретної руки
def generate_reward(action):
    # Припустимо, що нагорода генерується з нормального розподілу з центром в діапазоні [0, 1]
    return np.random.normal(loc=0.5, scale=0.1) if action == np.argmax(true_values) else np.random.normal(loc=0, scale=0.1)

# Істинні значення для кожної руки
true_values = np.random.normal(size=num_actions)

# Імплементація ε-жадібної стратегії
def epsilon_greedy(Q, epsilon):
    if np.random.rand() < epsilon:
        # Рандомний вибір руки
        return np.random.choice(num_actions)
    else:
        # Вибір руки з найвищою оцінкою
        return np.argmax(Q)

# Імплементація Softmax стратегії
def softmax(Q, tau=1.0):
    probabilities = np.exp(Q / tau) / np.sum(np.exp(Q / tau))
    return np.random.choice(num_actions, p=probabilities)

# Імплементація UCB стратегії
def ucb(Q, t, c=2):
    exploration_term = c * np.sqrt(np.log(t + 1) / np.sum(t))
    return np.argmax(Q + exploration_term)

# Функція для проведення експериментів
def run_experiment(strategy, epsilon=None, tau=None, c=None, num_steps=1000):
    Q = np.zeros(num_actions)  # Оцінки кожної руки
    N = np.zeros(num_actions)  # Кількість вибору кожної руки
    rewards = np.zeros(num_steps)  # Збереження отриманих нагород

    for t in range(num_steps):
        action = strategy(Q, t, epsilon=epsilon, tau=tau, c=c)
        reward = generate_reward(action)

        N[action] += 1
        Q[action] += (reward - Q[action]) / N[action]

        rewards[t] = reward

    return rewards

# Проведення серії експериментів
num_experiments = 100
epsilon_rewards = np.zeros((num_experiments, 1000))
softmax_rewards = np.zeros((num_experiments, 1000))
ucb_rewards = np.zeros((num_experiments, 1000))

for i in range(num_experiments):
    epsilon_rewards[i] = run_experiment(epsilon_greedy, epsilon=0.1)
    softmax_rewards[i] = run_experiment(softmax, tau=0.5)
    ucb_rewards[i] = run_experiment(ucb, c=2)

# Відображення результатів
plt.plot(np.mean(epsilon_rewards, axis=0), label='ε-Greedy')
plt.plot(np.mean(softmax_rewards, axis=0), label='Softmax')
plt.plot(np.mean(ucb_rewards, axis=0), label='UCB')
plt.xlabel('Steps')
plt.ylabel('Average Reward')
plt.legend()
plt.show()
