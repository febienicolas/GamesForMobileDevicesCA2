# Unity Ads Engine Integration test project

Test project for Unity Ads SDK using Engine Integration. Project is maintained using Unity 5.3, however can be opened in later Unity versions.

## How to use this project

First

1. Switch to relevant repo branch, e.g. `5.3`, using e.g. `git checkout 5.3` from command line (branch name indicates which Unity version is used to maintain project, can be opened in later Unity versions)

Then

1. Open `UnityAdsEngineIntegrationTest` project in Unity
1. Open MainScene
1. Play in editor or deploy to your Android or iOS device

Alternatively see `build.sh` script for how to automate building of project.

## Logging

Unity Ads related device logs are written with topic `UnityAds`, e.g. to filter relevant logs on Android, use:

```
$ adb logcat -v time UnityAds:V *:S
```

## Support

Please use <http://forum.unity3d.com/forums/unity-ads.67> for questions related to this project.

Hope you find this project useful as example and test application for Unity Ads asset store package.

Best regards,  
Your Unity Ads team
