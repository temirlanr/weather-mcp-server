### Setup and Configuration
Open with VS Code and install the recommended extensions if needed.
Start the MCP Server (I launched it by just clicking on the button that comes up in mcp.json file in .vscode folder)
If you don't have the MCP Server added or want to use your own mcp.json file, click Ctrl+Shift+P in VS Code and search for [MCP: Add Server]. Then proceed as above.
 
Open the Copilot chat on the left side of the screen and select the Ask mode, Model doesn't matter, click [Add Context...] -> [Tools...] -> [current_weather/forecast_weather].
Now you can ask questions about the current weather or forecast weather, and the Copilot will use the MCP Server to provide answers.

### Implementation Approach
I wanted to use Clean Architecture, so I created an Application layer with a Contract IWeatherService, but I thought creating an Infrastructure layer with a WeatherService implementation would be too much for this simple example, so I just created a WeatherService in the Application layer and implemented it there.
Getting current weather was very simple, because of 1 parameter.
Getting a forecast with 2 parameters, to have options to set time was tricky and I still don't know how to do it, because AI agents don't provide with second parameter, only 1 of them.
Therefore, I left it as it is and made hours parameter constant. 
Also, at first I used the wrong API endpoint and it turned out to be paywalled which took time to fix.
After all that I realized I was spending too much time on this so I decided to skip Unit testing.