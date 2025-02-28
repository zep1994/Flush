# Flush

**Flush** is a mobile application designed to help users locate public restrooms quickly and efficiently. Leveraging a vast database of facilities, it provides real-time information on nearby toilets, including accessibility features and user reviews.

## 🚀 Features

- **Real-Time Location**: Find the nearest public restrooms based on your current location.
- **Accessibility Information**: Details on facilities equipped for disabled access.
- **User Reviews and Ratings**: Share and read experiences from other users.
- **Offline Access**: Access restroom locations even without an internet connection.

## 🛠 Technologies Used

### Backend

- **C#**: Primary programming language.
- **ASP.NET Core**: Framework for building the API.
- **Entity Framework Core**: ORM for database interactions.

### Frontend

- **.NET MAUI**: Cross-platform framework for building native mobile apps.
- **XAML**: Markup language for designing user interfaces.

## 📦 Installation & Setup

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) with .NET MAUI workload installed

### Steps

1. **Clone the Repository**:
   ```sh
   git clone https://github.com/zep1994/Flush.git
   cd Flush
   ```

2. **Setup the Backend**:
   - Navigate to the API project directory:
     ```sh
     cd Flush_API
     ```
   - Restore dependencies and build the project:
     ```sh
     dotnet restore
     dotnet build
     ```
   - Update the `appsettings.json` file with your database connection string.
   - Apply database migrations:
     ```sh
     dotnet ef database update
     ```
   - Run the API:
     ```sh
     dotnet run
     ```

3. **Setup the Frontend**:
   - Navigate to the client project directory:
     ```sh
     cd ../Flush_Client
     ```
   - Restore dependencies:
     ```sh
     dotnet restore
     ```
   - Run the application:
     ```sh
     dotnet build
     dotnet run
     ```

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch:
   ```sh
   git checkout -b feature-branch
   ```
3. Commit your changes:
   ```sh
   git commit -m "Description of changes"
   ```
4. Push to the branch:
   ```sh
   git push origin feature-branch
   ```
5. Open a Pull Request detailing your changes.

## 📄 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

## 📞 Contact

For questions or support, please contact the project maintainer at [thomasmatlockbba@gmail.com](mailto:thomasmatlockbba@gmail.com).
