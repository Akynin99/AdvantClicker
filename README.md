# AdvantClicker

A Unity-based idle/clicker game using ECS (Entity Component System) architecture.

**Unity 2022.3.40f1**

## Project Structure

### Architecture Overview
The project follows an ECS (Entity Component System) architecture using Leopotam.Ecs framework, with a clear separation of concerns between different layers:

- **Core**: Base ECS UI components and entities
- **MonoBehaviours**: Unity components handling UI and user interaction
- **Components**: ECS components storing data and state
- **Systems**: ECS systems containing business logic
- **Configs**: Configuration data for businesses and game settings
- **Utils**: Helper utilities for common functionality


### Key Components

#### Core
- **EcsUIScreen**: Base class for ECS UI screens
- **EcsUIEntity**: Base class for ECS UI entities

#### MonoBehaviours
- **BusinessPanel**: UI component for displaying business information
- **BusinessUpgradeButton**: UI component for business upgrades
- **MainUIScreen**: Main UI screen component
- **WalletPanel**: UI component for displaying wallet information

#### Components
- **Business**: Core business data and state
- **BusinessView**: UI representation of business
- **BusinessUpgrade**: Business upgrade data
- **BusinessSaveData**: Business save data structure
- **Wallet**: Player's wallet data
- **WalletView**: UI representation of wallet
- **TryToLevelUpBusinessSignal**: Signal for level up actions
- **TryToUpgradeSignal**: Signal for upgrade actions

#### Systems
- **BusinessInitSystem**: Initializes business entities
- **BusinessProgressSystem**: Manages business progress
- **BusinessIncomeSystem**: Handles income calculations
- **BusinessLevelUpSystem**: Manages level up logic
- **BusinessUpgradeSystem**: Handles upgrade purchases
- **BusinessSaveSystem**: Manages business save data
- **BusinessPanelUpdateSystem**: Updates business UI
- **WalletInitSystem**: Initializes wallet
- **WalletSaveSystem**: Manages wallet save data
- **WalletViewUpdateSystem**: Updates wallet UI

#### Configs
- **BusinessConfig**: Business configuration data
- **BusinessUpgradeConfig**: Upgrade configuration data
- **GameConfig**: General game settings
- **NamesConfig**: Business and upgrade names
