# chargen-nancy

[![Build status](https://ci.appveyor.com/api/projects/status/3gglyn3p7qjew4wc?svg=true)](https://ci.appveyor.com/project/tomizechsterson/chargen-nancy)

These services are another backend for the [chargen-ui](https://github.com/tomizechsterson/chargen-ui) ReactJS project. This is simply an attempt to use the NancyFx framework for something a bit more than a 'hello world' app. This means that this project will also not implement every required feature in order to end up with a fully created and playable character for any of these games.

## Getting Started

I've been developing this on Windows, but using non-Microsoft tools, so this should build and run on all OS's without too much trouble.

### Prerequisites

Be sure to have the latest versions of these installed:
- [Git](https://git-scm.com/)
   - This is what you need to pull the code down to your machine and submit changes to the repo
- [.Net Core](https://www.microsoft.com/net/download) (Make sure to download the SDK, which I believe includes the Runtime)
  - This will allow you to run the `dotnet` commands to start the dev server and compile the project
  
### Installing

- Make a folder for the code and run `git clone https://github.com/tomizechsterson/chargen-nancy`
  - This will pull down the latest version of the code and copy it into the `chargen-nancy` folder
- Navigate into this folder with your terminal of choice
- Run `dotnet restore` at the root of the project

At this point, the project should be ready to build and run in your IDE of choice. If not, feel free to open an issue and I'll see what I can do.

## Contributing

If you'd like to contribute, feel free to open a PR with the changes you'd like to make, and I'll be happy to review it. I'll try to get to it promptly, but I make no promises :)

## License

This project is licensed under the GNU General Public License - see the [LICENSE.md](LICENSE.md) file for details
