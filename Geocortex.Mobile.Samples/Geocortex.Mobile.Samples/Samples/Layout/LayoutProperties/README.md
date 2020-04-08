# Layout Properties

### Description
This sample demonstrates various layout position properties for xml layout.

### Tips
Layout properties include:
- id
  - A unique ID for the component.
- title
  - A human-readable title for the component. Where the title appears (or whether it appears at all) varies with each type of component.
- icon
  - A resource key that can be mapped to an image for the icon. Where the icon appears (or whether it appears at all) varies with each type of component.
- config
  - The ID of a corresponding item in a Geocortex Mobile app that contains this component's configuration.
- width
  - The width of the component, in em units.
- height
  - the height of the component, in em units.
- margin
  - the margin around the component, in em units.
- padding
  - the padding within the component, in em units.
- halign
  - Describes how the content of a component is horizontally aligned. For stacks and splits, the content is the child components. For a component like text, the content is the text itself.
  - Valid values are "start", "center", "end"
- valign
  - Describes how the content of a component is vertically aligned. For stacks and splits, the content is the child components. For a component like text, the content is the text itself.
  - Valid values are "start", "center", "end"
- grow
  - Sets whether or not a component's width or height will grow over its parents primary axis. Components with a grow of 0 will fill to their natural or requested width/height. Components with a specified grow will fill up a percentage of the remaining space equal to their grow value divided by the total grow of all sibling components (including the component in question).
- slot
  - When a component is nested inside of another component, it may explicitly reference a named "slot" in the parent component to indicate where the child should appear.
- active
  - Specifies whether a component is active by default or not. When this attribute is not defined, the parent component decides the child's behavior. In Web, an inactive component means that the component is initially not visible. An active component means the component is initially visible. In Mobile, inactive and active components are up to the interpretation of the parent to decide on how to render.
