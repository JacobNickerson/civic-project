## GETTING STARTED

To run this app locally, follow these steps. Development was done on Archlinux, but these steps should be easily replicable on any other distro. This should also be easy to do on Windows, but may require some tweaking.

### PREREQUISITES

* dotnet
* dotnet-sdk
* aspnet-runtime

These can easily be installed using any package manager:

Debian-based distros
```sh
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install -y dotnet-runtime-8.0
sudo apt-get install -y dotnet-sdk-8.0
sudo apt-get install -y aspnetcore-runtime-8.0
```

Redhat-based distros
```sh
sudo dnf update
sudo dnf install -y dotnet-runtime-8.0
sudo dnf install -y dotnet-sdk-8.0
sudo dnf install -y aspnetcore-runtime-8.0
```

Arch-based distros
```sh
sudo pacman -S dotnet dotnet-sdk aspnet-runtime
```

### Installation

1. Clone the repo
```sh
git clone git@github.com:edaraiseh/CEN3031CivicProject.git
```

2. Move into the project directory
```sh
cd CEN3031CivicProject
```

3. Switch to the `backend` branch
```sh
git switch backend
```

4. Move into the backend directory
```sh
cd backend
```

5. Compile and run the application
```sh
dotnet run
```
