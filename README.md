# KeenVPN - MVP VPN Client (Windows/.NET 9)

## Overview
KeenVPN is a native Windows MVP VPN client built with .NET 9 and WPF. It demonstrates secure user authentication (mocked), VPN node discovery, and simulated tunnel connection, following SOLID principles and clean architecture.

## Features
- Mocked email/password authentication
- VPN node list fetched from a mock REST endpoint
- Simulated VPN connection with UI state transitions
- Native Windows notifications
- Session management
- CI/CD with GitHub Actions
- Unit testing with xUnit

## Setup Instructions
1. **Prerequisites:**
   - .NET 9 SDK
   - Visual Studio 2022 or later (Windows)

2. **Clone the Repository:**
   ```sh
   git clone https://github.com/LexxLuey/basic-wpf-vpn.git
   cd basic-wpf-vpn
   ```

3. **Restore & Build:**
   ```sh
   dotnet restore
   dotnet build
   ```

4. **Run the App:**
   - Open in Visual Studio and press F5, or
   - Run: `dotnet run`
   - Login with  ("test@example.com", "password123") or ("user@vpn.com", "vpnpass")


## Architecture Explanation
- **Core:** Models and interfaces (`User`, `VpnNode`, `Session`, `IAuthService`, `IVpnService`)
- **Infrastructure:** Mock API and services (`MockAuthService`, `MockVpnService`, `SessionStore`)
- **Presentation:** WPF views and viewmodels (`SignInWindow`, `NodeListWindow`, `AuthViewModel`, `NodeListViewModel`)
- **Utilities:** Notification helper, value converters
- **CI/CD:** Automated build and test with GitHub Actions (`.github/workflows/dotnet.yml`)

## AI Prompts Used
- "As a senior full stack engineer, advise on how to build this mvp on Windows. Your proposed implementation overview should not go into code details but just high level options for delivering the highest quality mvp submission"
- "Create models for User, VpnNode, and Session."
- "Implement authentication flow with mock service."
- "Design Sign In screen in XAML."
- "Show Connect button for each VPN node."
- "Simulate VPN connection and toggle UI state."
- "Fix RelayCommand ambiguity."
- "Implement CI/CD workflow and unit tests."
- "Improve UX for Connect/Disconnect button."
- "Add proper cleanup on app exit."

## AI Bugs + Fixes
- **RelayCommand ambiguity:**
  - Fixed by creating a single reusable RelayCommand class.
- **Connect button not showing:**
  - Fixed by switching from GridView to ItemTemplate in ListView.
- **TextBlock showing literal binding:**
  - Fixed by using proper binding syntax and StringFormat.
- **All nodes showing Disconnect:**
  - Fixed by per-node IsConnected/CanConnect properties and value converter.
- **Session not cleaned up on exit:**
  - Fixed by overriding OnExit in App.xaml.cs.

## Mock API Structure
- **Authentication:**
  - `MockAuthService` uses in-memory or local JSON user list.
- **Node Discovery:**
  - `MockVpnService` provides a list of VpnNode objects (name, country, latency, public key, endpoint IP).
- **Session:**
  - `SessionStore` object stores current user and connected node in memory.

## Demo Video
See `https://drive.google.com/file/d/1zqfdEUylsg4JeURMnKmL5Ss0TeFnkxOT/view?usp=drive_link` for a walkthrough of the app and architecture.

## License
MIT
