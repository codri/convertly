# List of improvements and ideas

## Interface quality

- Handle Hi-DPI screens
  - Display more information on the screen when possible
- Theming
  - Handle system settings light/dark theme
    - This will probably require to implement our own windows decorations
  - Application Icons(Window Icon, Tray Icon)
- Code Reuse
  - Add WPF styles for components, so the styling information is not inline
    - This makes it more difficult to update the component styling in the future, by adding a new layer of indirection
  - Custom Controls
    - Such a small project doesn't need them ATM, but might in the future

## Correctness

- We're working with floating point values which are unreliable
  - BigFloat should help
- Multilingual Units
- Multilingual number formatting
- Handle scientific notation for input(if not handled natively by parse double) ex: 1e2

## Quality

- Code Coverage
- Testing
  - Add unit tests for the ViewModel
  - Property based tests would cover a lot of space in this domain
- Linters and SonarQube Quality Gates
- Logging

## Performance

- Startup time
  - AoT Compilation can help with this
- Memory usage
- Responsive UI thread
  - If we were to run some CPU intensive logic, we'd want to move that to a worker thread
- Debounce on input
  - The user can type a lot of digits quickly, we don't want to convert the values for intermediary numbers, maybe it's worth adding a delay so we reduce the work done

## Deployment

- App Installer
  - Publishing as a self contained binary should allow deployments to machines without a .NET 6 runtime
- App updates
  - Decide on a way to do live/in-place updates(if allowed by OS)

## Potential features

- History
  - Keep a history of converted values for later use
  - Use additional screen space when available to display the conversion history
  - This will require a data storage solution, ex: Sqlite and probably and ORM to use it(Dapper, EFCore)
- Calculate basic mathematic expressions inside the input field(TextBox)
- Allow for flipping the units, so the user doesn't have to select them again
- Search
  - With a large number of unit types it might be easier to allow for the user to search for the source and target types, with fuzzy searching
