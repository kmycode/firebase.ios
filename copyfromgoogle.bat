@echo off

if "%1" == "" goto err_1

copy "%1\Analytics\FirebaseAnalytics.framework\FirebaseAnalytics" "Firebase.iOS.Analytics\FirebaseAnalytics.a"
copy "%1\Analytics\FirebaseInstanceID.framework\FirebaseInstanceID" "Firebase.iOS.Analytics\FirebaseInstanceID.a"
copy "%1\Analytics\GoogleInterchangeUtilities.framework\GoogleInterchangeUtilities" "Firebase.iOS.Analytics\GoogleInterchangeUtilities.a"
copy "%1\Analytics\GoogleSymbolUtilities.framework\GoogleSymbolUtilities" "Firebase.iOS.Analytics\GoogleSymbolUtilities.a"
copy "%1\Analytics\GoogleUtilities.framework\GoogleUtilities" "Firebase.iOS.Analytics\GoogleUtilities.a"
copy "%1\Auth\FirebaseAuth.framework\FirebaseAuth" "Firebase.iOS.Auth\FirebaseAuth.a"
copy "%1\Auth\GoogleNetworkingUtilities.framework\GoogleNetworkingUtilities" "Firebase.iOS.Auth\GoogleNetworkingUtilities.a"
copy "%1\Database\FirebaseDatabase.framework\FirebaseDatabase" "Firebase.iOS.Database\FirebaseDatabase.a"
copy "%1\Storage\FirebaseStorage.framework\FirebaseStorage" "Firebase.iOS.Storage\FirebaseStorage.a"
copy "%1\Storage\GoogleNetworkingUtilities.framework\GoogleNetworkingUtilities" "Firebase.iOS.Storage\GoogleNetworkingUtilities.a"
copy "%1\RemoteConfig\FirebaseRemoteConfig.framework\FirebaseRemoteConfig" "Firebase.iOS.RemoteConfig\FirebaseRemoteConfig.a"
copy "%1\RemoteConfig\GoogleIPhoneUtilities.framework\GoogleIPhoneUtilities" "Firebase.iOS.RemoteConfig\GoogleIPhoneUtilities.a"
copy "%1\Messaging\FirebaseMessaging.framework\FirebaseMessaging" "Firebase.iOS.Messaging\FirebaseMessaging.a"
copy "%1\Messaging\GoogleIPhoneUtilities.framework\GoogleIPhoneUtilities" "Firebase.iOS.Messaging\GoogleIPhoneUtilities.a"
goto end

:err_1
echo Firebaseライブラリのパスが指定されていません
goto end

:end


