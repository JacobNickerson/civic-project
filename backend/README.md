## GETTING STARTED

To run this app locally, follow these steps. Development was done on Archlinux, but these steps should be easily replicable on any other distro. This should also be easy to do on Windows, but may require some tweaking.

### PREREQUISITES

* dotnet-runtime
* aspnet-runtime
* dotnet-sdk

These can easily be installed using any package manager, on any arch-based distro this is:
```sh
sudo pacman -S dotnet dotnet-sdk aspnet-runtime
```

### Installation

1. Clone the repo
```sh
git clone git@github.com:edaraiseh/CEN3031CivicProject.git
```

2. Move into backend directory
```sh
cd CEN3031CivicProject/backend
```

3. Compile and run the application
```sh
dotnet run
```