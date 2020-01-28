# SignalR .NET Core + Angular App
Simple project for a SignalR application with one backend and 3 clients. 
The structure is the following:

 - Backend project in .NET Core. This backend has one controller and one hub that will handle the connections and will notify the clients.
 - Clients:
	 - 2 clients to receive data with different users ids.
	 - 1 client to send GET requests to the controller to notify the other clients


## Getting Started

Use these instructions to get the project up and running.

### Prerequisites

You will need the following tools:

-   [Visual Studio Code or Visual Studio 2019](https://visualstudio.microsoft.com/)
-   [.NET Core SDK 3](https://dotnet.microsoft.com/download/dotnet-core/3.1)
-   [Node.js](https://nodejs.org/en/)  (version 10 or later) with npm (version 6.9.0 or later)
-   [Angular CLI]([https://angular.io/cli](https://angular.io/cli))  (version 7 or later)

### Setup

Follow these steps to get your development environment set up:

1.  Clone the repository
2.  Launch backend the project using:
    
    ```
    dotnet run --urls="http://localhost:65179"
    ```
    
3. Launch the client 1&2 projects (that will receive data from the server).
	```
	npm install
    ng serve --port 4200
    ng serve --port 4201
    ```
4. Launch the client 3 projects (that will receive data from the server)
	```
	npm install
    ng serve --port 4202
    ```
5. Open  the three clients on a browser to see how the requests made by the client 3, are received by the client 1, 2 or both.

## Technologies

-   ASP.NET Core 3.1
-   Angular CLI 7
-   Angular 7

## Authors
* **Joan-Ignasi Gil Pons** - [Github](https://github.com/JoanGil)
* **Michel Dennis Quitaquís** - [Github](https://github.com/polo070770)

## License

This project is licensed under the MIT License.

