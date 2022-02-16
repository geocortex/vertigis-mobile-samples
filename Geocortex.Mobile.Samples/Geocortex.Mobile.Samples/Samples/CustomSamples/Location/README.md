# Location

### Description
A location component that gets the user's latitude and longitude.

### Tips
- This is not the recommended pattern for accessing location in a VertiGIS Studio Mobile application.
- This sample component is for illustrative purposes only.
  - This sample demonstrates Xamarin's **DependencyService** pattern, allowing platform specific implementations and api/method calls.
  - The ILocation class is implemented by each platform (Android, iOS, and UWP) in their respective projects.
