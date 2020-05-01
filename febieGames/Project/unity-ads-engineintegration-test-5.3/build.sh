#!/bin/bash

# NOTE: This is a test script used by Unity Ads team to verify Ads SDK versions
# against different Unity versions. Parameters and usage of this script may change
# in future versions, but is included here as example of how to automate this
# process, which might be relevant to others

if [ -z "$2" ]; then
    echo "Build Unity Ads SDK example project on OS X"
    echo
    echo "./build.sh platform(s) unity-path"
    echo
    echo "Examples:"
    echo "  ./build.sh android,ios \"/Applications/Unity 5.4.0f3\""
    echo
    echo "Unity version e.g. \"5.4.0f3\" must be installed on the machine in specified folder"
    exit 1
fi

# parameters
PLATFORMS=$1
UNITY="$2/Unity.app/Contents/MacOS/Unity"

PROJECT_PATH="$(pwd)/UnityAdsEngineIntegrationTest"
EDITOR_LOG_MSG="Please check ~/Library/Logs/Unity/Editor.log"

if [ ! -f "$UNITY" ]; then
    echo "Could not find Unity executable in '$UNITY'. Please verify it's installed and available in that location"
    exit 1
fi

if [[ $PLATFORMS =~ .*android.* ]]; then
    echo Building project for Android...
    APK_PATH="UnityAdsEngineIntegrationTest/Builds/Android.apk"
    if [ -f "$APK_PATH" ]; then
        rm "$APK_PATH"
    fi
    "$UNITY" -projectPath "$PROJECT_PATH" -executeMethod AutoBuilder.PerformAndroidBuild -skipMissingUPID -batchMode -quit
    rc=$?; if [[ $rc != 0 ]]; then
        echo "Unity build for Android failed. $EDITOR_LOG_MSG"
        exit $rc
    fi

    if [ ! -f "$APK_PATH" ]; then
        echo "Failed to build APK file ($APK_PATH). $EDITOR_LOG_MSG"
        exit 1
    fi

    # TODO: Deploy to device
    # echo Installing on Android device...
    # adb install -r "$APK_PATH"
    # adb shell am start -S -a android.intent.action.MAIN -n com.unity3d.unityads.EngineTest/com.unity3d.player.UnityPlayerActivity
fi

if [[ $PLATFORMS =~ .*ios.* ]]; then
    echo Building project for iOS...
    IOS_PATH="UnityAdsEngineIntegrationTest/Builds/iOS"
    if [ -d "$IOS_PATH" ]; then
        rm -rf "$IOS_PATH"
    fi
    "$UNITY" -projectPath "$PROJECT_PATH" -executeMethod AutoBuilder.PerformiOSBuild -skipMissingUPID -batchMode -quit
    rc=$?; if [[ $rc != 0 ]]; then
        echo "Unity build for iOS failed. $EDITOR_LOG_MSG"
        exit $rc
    fi

    XCODEPROJ_PATH="$IOS_PATH/Unity-iPhone.xcodeproj"
    if [ ! -d "$XCODEPROJ_PATH" ]; then
        echo "Failed to build iOS project ($XCODEPROJ_PATH). $EDITOR_LOG_MSG"
        exit 1
    fi

    # TODO: Deploy to device
    # open $IOS_PATH/Unity-iPhone.xcodeproj
    # xcodebuild -project $IOS_PATH/Unity-iPhone.xcodeproj
fi
