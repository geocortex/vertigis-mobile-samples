# Custom Details

### Description
A custom details component that displays information about a feature.

### Tips
- Custom details is implemented with a component, operation, and view.
- The **custom.display-details** operation is used in the app's json configuration.
  - The map-extension's **onClick** performs a _tasks.identify_, returning a MapExtensionFeatureResultArgs
  - The MapExtensionFeatureResultArgs is used as an input to the **custom.display-details** operation.
