using System;

using ObjCRuntime;
using Foundation;
using UIKit;

using CoreFoundation;
//using FirebaseDatabase;

using Firebase.iOS.Analytics;

namespace Firebase.iOS.Analytics
{
	// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
	// to the project by right-clicking (or Control-clicking) the folder containing this source
	// file and clicking "Add files..." and then simply select the native library (or libraries)
	// that you want to bind.
	//
	// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
	// native library which will contain a [LinkWith] attribute. VisualStudio auto-detects the
	// architectures that the native library supports and fills in that information for you,
	// however, it cannot auto-detect any Frameworks or other system libraries that the
	// native library may depend on, so you'll need to fill in that information yourself.
	//
	// Once you've done that, you're ready to move on to binding the API...
	//
	//
	// Here is where you'd define your API definition for the native Objective-C library.
	//
	// For example, to bind the following Objective-C class:
	//
	//     @interface Widget : NSObject {
	//     }
	//
	// The C# binding would look like this:
	//
	//     [BaseType (typeof (NSObject))]
	//     interface Widget {
	//     }
	//
	// To bind Objective-C properties, such as:
	//
	//     @property (nonatomic, readwrite, assign) CGPoint center;
	//
	// You would add a property definition in the C# interface like so:
	//
	//     [Export ("center")]
	//     CGPoint Center { get; set; }
	//
	// To bind an Objective-C method, such as:
	//
	//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
	//
	// You would add a method definition to the C# interface like so:
	//
	//     [Export ("doSomething:atIndex:")]
	//     void DoSomething (NSObject object, int index);
	//
	// Objective-C "constructors" such as:
	//
	//     -(id)initWithElmo:(ElmoMuppet *)elmo;
	//
	// Can be bound as:
	//
	//     [Export ("initWithElmo:")]
	//     IntPtr Constructor (ElmoMuppet elmo);
	//
	// For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_types
	//
}

// Analytics.a
namespace Firebase.iOS.Analytics
{
	// @interface FIRAnalytics : NSObject
	[BaseType(typeof(NSObject))]
	interface FIRAnalytics
	{
		// +(void)logEventWithName:(NSString * _Nonnull)name parameters:(NSDictionary<NSString *,NSObject *> * _Nullable)parameters;
		[Static]
		[Export("logEventWithName:parameters:")]
		void LogEventWithName(string name, [NullAllowed] NSDictionary<NSString, NSObject> parameters);

		// +(void)setUserPropertyString:(NSString * _Nullable)value forName:(NSString * _Nonnull)name;
		[Static]
		[Export("setUserPropertyString:forName:")]
		void SetUserPropertyString([NullAllowed] string value, string name);

		// +(void)setUserID:(NSString * _Nullable)userID;
		[Static]
		[Export("setUserID:")]
		void SetUserID([NullAllowed] string userID);
	}

	// @interface AppDelegate (FIRAnalytics)
	[Category]
	[BaseType(typeof(FIRAnalytics))]
	interface FIRAnalytics_AppDelegate
	{
		// +(void)handleEventsForBackgroundURLSession:(NSString *)identifier completionHandler:(void (^)(void))completionHandler;
		[Static]
		[Export("handleEventsForBackgroundURLSession:completionHandler:")]
		void HandleEventsForBackgroundURLSession(string identifier, Action completionHandler);

		// +(void)handleOpenURL:(NSURL *)url;
		[Static]
		[Export("handleOpenURL:")]
		void HandleOpenURL(NSUrl url);

		// +(void)handleUserActivity:(id)userActivity;
		[Static]
		[Export("handleUserActivity:")]
		void HandleUserActivity(NSObject userActivity);
	}

	// @interface FIRAnalyticsConfiguration : NSObject
	[BaseType(typeof(NSObject))]
	interface FIRAnalyticsConfiguration
	{
		// +(FIRAnalyticsConfiguration *)sharedInstance;
		[Static]
		[Export("sharedInstance")]
		//[Verify (MethodToProperty)]
		FIRAnalyticsConfiguration SharedInstance { get; }

		// -(void)setMinimumSessionInterval:(NSTimeInterval)minimumSessionInterval;
		[Export("setMinimumSessionInterval:")]
		void SetMinimumSessionInterval(double minimumSessionInterval);

		// -(void)setSessionTimeoutInterval:(NSTimeInterval)sessionTimeoutInterval;
		[Export("setSessionTimeoutInterval:")]
		void SetSessionTimeoutInterval(double sessionTimeoutInterval);

		// -(void)setAnalyticsCollectionEnabled:(BOOL)analyticsCollectionEnabled;
		[Export("setAnalyticsCollectionEnabled:")]
		void SetAnalyticsCollectionEnabled(bool analyticsCollectionEnabled);

		// -(void)setIsEnabled:(BOOL)isEnabled __attribute__((deprecated("Use setAnalyticsCollectionEnabled: instead.")));
		[Export("setIsEnabled:")]
		void SetIsEnabled(bool isEnabled);
	}

	// typedef void (^FIRAppVoidBoolCallback)(BOOL);
	delegate void FIRAppVoidBoolCallback(bool arg0);

	// @interface FIRApp : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface FIRApp
	{
		// +(void)configure;
		[Static]
		[Export("configure")]
		void Configure();

		// +(void)configureWithOptions:(FIROptions * _Nonnull)options;
		[Static]
		[Export("configureWithOptions:")]
		void ConfigureWithOptions(FIROptions options);

		// +(void)configureWithName:(NSString * _Nonnull)name options:(FIROptions * _Nonnull)options;
		[Static]
		[Export("configureWithName:options:")]
		void ConfigureWithName(string name, FIROptions options);

		// +(FIRApp * _Nullable)defaultApp;
		[Static]
		[NullAllowed, Export("defaultApp")]
		//[Verify (MethodToProperty)]
		FIRApp DefaultApp { get; }

		// +(FIRApp * _Nullable)appNamed:(NSString * _Nonnull)name;
		[Static]
		[Export("appNamed:")]
		[return: NullAllowed]
		FIRApp AppNamed(string name);

		// +(NSDictionary * _Nullable)allApps;
		[Static]
		[NullAllowed, Export("allApps")]
		//[Verify (MethodToProperty)]
		NSDictionary AllApps { get; }

		// -(void)deleteApp:(FIRAppVoidBoolCallback _Nonnull)completion;
		[Export("deleteApp:")]
		void DeleteApp(FIRAppVoidBoolCallback completion);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export("name")]
		string Name { get; }

		// @property (readonly, nonatomic) FIROptions * _Nonnull options;
		[Export("options")]
		FIROptions Options { get; }
	}

	// @interface FIRConfiguration : NSObject
	[BaseType(typeof(NSObject))]
	interface FIRConfiguration
	{
		// +(FIRConfiguration *)sharedInstance;
		[Static]
		[Export("sharedInstance")]
		//[Verify (MethodToProperty)]
		FIRConfiguration SharedInstance { get; }

		// @property (readwrite, nonatomic) FIRAnalyticsConfiguration * analyticsConfiguration;
		[Export("analyticsConfiguration", ArgumentSemantic.Assign)]
		FIRAnalyticsConfiguration AnalyticsConfiguration { get; set; }

		// @property (assign, readwrite, nonatomic) FIRLogLevel logLevel;
		[Export("logLevel", ArgumentSemantic.Assign)]
		FIRLogLevel LogLevel { get; set; }
	}

	// @interface FIROptions : NSObject <NSCopying>
	[BaseType(typeof(NSObject))]
	interface FIROptions : INSCopying
	{
		// +(FIROptions *)defaultOptions;
		[Static]
		[Export("defaultOptions")]
		//[Verify (MethodToProperty)]
		FIROptions DefaultOptions { get; }

		// @property (readonly, copy, nonatomic) NSString * APIKey;
		[Export("APIKey")]
		string APIKey { get; }

		// @property (readonly, copy, nonatomic) NSString * clientID;
		[Export("clientID")]
		string ClientID { get; }

		// @property (readonly, copy, nonatomic) NSString * trackingID;
		[Export("trackingID")]
		string TrackingID { get; }

		// @property (readonly, copy, nonatomic) NSString * GCMSenderID;
		[Export("GCMSenderID")]
		string GCMSenderID { get; }

		// @property (readonly, copy, nonatomic) NSString * androidClientID;
		[Export("androidClientID")]
		string AndroidClientID { get; }

		// @property (readonly, copy, nonatomic) NSString * googleAppID;
		[Export("googleAppID")]
		string GoogleAppID { get; }

		// @property (readonly, copy, nonatomic) NSString * databaseURL;
		[Export("databaseURL")]
		string DatabaseURL { get; }

		// @property (readwrite, copy, nonatomic) NSString * deepLinkURLScheme;
		[Export("deepLinkURLScheme")]
		string DeepLinkURLScheme { get; set; }

		// @property (readonly, copy, nonatomic) NSString * storageBucket;
		[Export("storageBucket")]
		string StorageBucket { get; }

		// -(instancetype)initWithGoogleAppID:(NSString *)googleAppID bundleID:(NSString *)bundleID GCMSenderID:(NSString *)GCMSenderID APIKey:(NSString *)APIKey clientID:(NSString *)clientID trackingID:(NSString *)trackingID androidClientID:(NSString *)androidClientID databaseURL:(NSString *)databaseURL storageBucket:(NSString *)storageBucket deepLinkURLScheme:(NSString *)deepLinkURLScheme;
		[Export("initWithGoogleAppID:bundleID:GCMSenderID:APIKey:clientID:trackingID:androidClientID:databaseURL:storageBucket:deepLinkURLScheme:")]
		IntPtr Constructor(string googleAppID, string bundleID, string GCMSenderID, string APIKey, string clientID, string trackingID, string androidClientID, string databaseURL, string storageBucket, string deepLinkURLScheme);
	}
}

// InstanceID.a
namespace Firebase.iOS.Analytics
{
	[Static]
	//[Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull kFIRInstanceIDScopeFirebaseMessaging;
		[Field("kFIRInstanceIDScopeFirebaseMessaging", "__Internal")]
		NSString kFIRInstanceIDScopeFirebaseMessaging { get; }

		// extern NSString *const _Nonnull kFIRInstanceIDTokenRefreshNotification;
		[Field("kFIRInstanceIDTokenRefreshNotification", "__Internal")]
		NSString kFIRInstanceIDTokenRefreshNotification { get; }
	}

	// typedef void (^FIRInstanceIDTokenHandler)(NSString * _Nullable, NSError * _Nullable);
	delegate void FIRInstanceIDTokenHandler([NullAllowed] string arg0, [NullAllowed] NSError arg1);

	// typedef void (^FIRInstanceIDDeleteTokenHandler)(NSError * _Nullable);
	delegate void FIRInstanceIDDeleteTokenHandler([NullAllowed] NSError arg0);

	// typedef void (^FIRInstanceIDHandler)(NSString * _Nullable, NSError * _Nullable);
	delegate void FIRInstanceIDHandler([NullAllowed] string arg0, [NullAllowed] NSError arg1);

	// typedef void (^FIRInstanceIDDeleteHandler)(NSError * _Nullable);
	delegate void FIRInstanceIDDeleteHandler([NullAllowed] NSError arg0);

	// @interface FIRInstanceID : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface FIRInstanceID
	{
		// +(instancetype _Nonnull)instanceID;
		[Static]
		[Export("instanceID")]
		FIRInstanceID InstanceID();

		// -(void)setAPNSToken:(NSData * _Nonnull)token type:(FIRInstanceIDAPNSTokenType)type;
		[Export("setAPNSToken:type:")]
		void SetAPNSToken(NSData token, FIRInstanceIDAPNSTokenType type);

		// -(NSString * _Nullable)token;
		[NullAllowed, Export("token")]
		//[Verify(MethodToProperty)]
		string Token { get; }

		// -(void)tokenWithAuthorizedEntity:(NSString * _Nonnull)authorizedEntity scope:(NSString * _Nonnull)scope options:(NSDictionary * _Nullable)options handler:(FIRInstanceIDTokenHandler _Nonnull)handler;
		[Export("tokenWithAuthorizedEntity:scope:options:handler:")]
		void TokenWithAuthorizedEntity(string authorizedEntity, string scope, [NullAllowed] NSDictionary options, FIRInstanceIDTokenHandler handler);

		// -(void)deleteTokenWithAuthorizedEntity:(NSString * _Nonnull)authorizedEntity scope:(NSString * _Nonnull)scope handler:(FIRInstanceIDDeleteTokenHandler _Nonnull)handler;
		[Export("deleteTokenWithAuthorizedEntity:scope:handler:")]
		void DeleteTokenWithAuthorizedEntity(string authorizedEntity, string scope, FIRInstanceIDDeleteTokenHandler handler);

		// -(void)getIDWithHandler:(FIRInstanceIDHandler _Nonnull)handler;
		[Export("getIDWithHandler:")]
		void GetIDWithHandler(FIRInstanceIDHandler handler);

		// -(void)deleteIDWithHandler:(FIRInstanceIDDeleteHandler _Nonnull)handler;
		[Export("deleteIDWithHandler:")]
		void DeleteIDWithHandler(FIRInstanceIDDeleteHandler handler);
	}
}


