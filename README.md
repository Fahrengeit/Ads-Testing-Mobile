# Ads-Testing-Mobile

This is a repository for the Unity project that provides simple functions of loading and showing ads through AppLovin MAX Mediation with room for expanding into other Mediations.

## Initialization

To get started with the application, follow the instructions below:

1. Clone this project and open it in the Unity Editor.
2. Choose your mobile platform (Android or iOS). This application was tested on iOS.
3. Update the iOS bundle identifier or Android package name with your own identifer that is connected to your MAX account.
4. Open the AdScene scene and navigate to AdController game object.
5. Update **MaxSdkKey** with your AppLovin SDK key that's associated with your account.
6. Update **AdUnitId** in  **InterstitialAdController** and **RewardedAdController** scripts with MAX ad unit IDs that you should create in MAX dashboard.
7. Build.

## Building

According to MAX Mediation Documentation (https://dash.applovin.com/documentation/mediation/unity/getting-started/integration)

For Android builds, the AppLovin MAX plugin requires that you enable Jetifier. To enable Jetifier, take the following steps:
1. In Unity, select Assets > External Dependency Manager > Android Resolver > Settings.
2. In the Android Resolver Settings dialog that appears, check Use Jetifier.
3. Click OK.

For iOS builds:
1. Your build will fail if you do not build with Xcode 12 or higher. The App Store now requires apps to be built with Xcode 12. AppLovin recommends that you update Xcode to version 12.5 or higher in order to stay ahead of anticipated minimum requirements.
2. The AppLovin MAX plugin requires CocoaPods. Install CocoaPods by following the instructions at the CocoaPods Getting Started guide.