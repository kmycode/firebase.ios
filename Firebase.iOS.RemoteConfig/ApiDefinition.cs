using System;

using ObjCRuntime;
using Foundation;
using UIKit;

namespace Firebase.iOS.RemoteConfig
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

namespace Firebase.iOS.RemoteConfig
{
	//[Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull FIRNamespaceGoogleMobilePlatform;
		[Static]
		[Field("FIRNamespaceGoogleMobilePlatform", "__Internal")]
		NSString FIRNamespaceGoogleMobilePlatform { get; }

		// extern NSString *const _Nonnull FIRRemoteConfigThrottledEndTimeInSecondsKey;
		[Static]
		[Field("FIRRemoteConfigThrottledEndTimeInSecondsKey", "__Internal")]
		NSString FIRRemoteConfigThrottledEndTimeInSecondsKey { get; }
	}

	//[Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull FIRRemoteConfigErrorDomain;
		[Static]
		[Field("FIRRemoteConfigErrorDomain", "__Internal")]
		NSString FIRRemoteConfigErrorDomain { get; }
	}

	// typedef void (^FIRRemoteConfigFetchCompletion)(FIRRemoteConfigFetchStatus, NSError * _Nullable);
	delegate void FIRRemoteConfigFetchCompletion(FIRRemoteConfigFetchStatus arg0, [NullAllowed] NSError arg1);

	// @interface FIRRemoteConfigValue : NSObject <NSCopying>
	[BaseType(typeof(NSObject))]
	interface FIRRemoteConfigValue : INSCopying
	{
		// @property (readonly, nonatomic) NSString * _Nullable stringValue;
		[NullAllowed, Export("stringValue")]
		string StringValue { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable numberValue;
		[NullAllowed, Export("numberValue")]
		NSNumber NumberValue { get; }

		// @property (readonly, nonatomic) NSData * _Nonnull dataValue;
		[Export("dataValue")]
		NSData DataValue { get; }

		// @property (readonly, nonatomic) BOOL boolValue;
		[Export("boolValue")]
		bool BoolValue { get; }

		// @property (readonly, nonatomic) FIRRemoteConfigSource source;
		[Export("source")]
		FIRRemoteConfigSource Source { get; }
	}

	// @interface FIRRemoteConfigSettings : NSObject
	[BaseType(typeof(NSObject))]
	interface FIRRemoteConfigSettings
	{
		// @property (readonly, nonatomic) BOOL isDeveloperModeEnabled;
		[Export("isDeveloperModeEnabled")]
		bool IsDeveloperModeEnabled { get; }

		// -(FIRRemoteConfigSettings * _Nullable)initWithDeveloperModeEnabled:(BOOL)developerModeEnabled __attribute__((objc_designated_initializer));
		[Export("initWithDeveloperModeEnabled:")]
		[DesignatedInitializer]
		IntPtr Constructor(bool developerModeEnabled);
	}

	interface INSFastEnumeration { }

	// @interface FIRRemoteConfig : NSObject <NSFastEnumeration>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface FIRRemoteConfig : INSFastEnumeration
	{
		// @property (readonly, nonatomic, strong) NSDate * _Nullable lastFetchTime;
		[NullAllowed, Export("lastFetchTime", ArgumentSemantic.Strong)]
		NSDate LastFetchTime { get; }

		// @property (readonly, assign, nonatomic) FIRRemoteConfigFetchStatus lastFetchStatus;
		[Export("lastFetchStatus", ArgumentSemantic.Assign)]
		FIRRemoteConfigFetchStatus LastFetchStatus { get; }

		// @property (readwrite, nonatomic, strong) FIRRemoteConfigSettings * _Nonnull configSettings;
		[Export("configSettings", ArgumentSemantic.Strong)]
		FIRRemoteConfigSettings ConfigSettings { get; set; }

		// +(FIRRemoteConfig * _Nonnull)remoteConfig;
		[Static]
		[Export("remoteConfig")]
		//[Verify(MethodToProperty)]
		FIRRemoteConfig RemoteConfig { get; }

		// -(void)fetchWithCompletionHandler:(FIRRemoteConfigFetchCompletion _Nullable)completionHandler;
		[Export("fetchWithCompletionHandler:")]
		void FetchWithCompletionHandler([NullAllowed] FIRRemoteConfigFetchCompletion completionHandler);

		// -(void)fetchWithExpirationDuration:(NSTimeInterval)expirationDuration completionHandler:(FIRRemoteConfigFetchCompletion _Nullable)completionHandler;
		[Export("fetchWithExpirationDuration:completionHandler:")]
		void FetchWithExpirationDuration(double expirationDuration, [NullAllowed] FIRRemoteConfigFetchCompletion completionHandler);

		// -(BOOL)activateFetched;
		[Export("activateFetched")]
		//[Verify(MethodToProperty)]
		bool ActivateFetched();

		// -(FIRRemoteConfigValue * _Nonnull)objectForKeyedSubscript:(NSString * _Nonnull)key;
		[Export("objectForKeyedSubscript:")]
		FIRRemoteConfigValue ObjectForKeyedSubscript(string key);

		// -(FIRRemoteConfigValue * _Nonnull)configValueForKey:(NSString * _Nullable)key;
		[Export("configValueForKey:")]
		FIRRemoteConfigValue ConfigValueForKey([NullAllowed] string key);

		// -(FIRRemoteConfigValue * _Nonnull)configValueForKey:(NSString * _Nullable)key namespace:(NSString * _Nullable)aNamespace;
		[Export("configValueForKey:namespace:")]
		FIRRemoteConfigValue ConfigValueForKey([NullAllowed] string key, [NullAllowed] string aNamespace);

		// -(FIRRemoteConfigValue * _Nonnull)configValueForKey:(NSString * _Nullable)key namespace:(NSString * _Nullable)aNamespace source:(FIRRemoteConfigSource)source;
		[Export("configValueForKey:namespace:source:")]
		FIRRemoteConfigValue ConfigValueForKey([NullAllowed] string key, [NullAllowed] string aNamespace, FIRRemoteConfigSource source);

		// -(NSArray * _Nonnull)allKeysFromSource:(FIRRemoteConfigSource)source namespace:(NSString * _Nullable)aNamespace;
		[Export("allKeysFromSource:namespace:")]
		//[Verify(StronglyTypedNSArray)]
		NSObject[] AllKeysFromSource(FIRRemoteConfigSource source, [NullAllowed] string aNamespace);

		// -(void)setDefaults:(NSDictionary<NSString *,NSObject *> * _Nullable)defaults;
		[Export("setDefaults:")]
		void SetDefaults([NullAllowed] NSDictionary<NSString, NSObject> defaults);

		// -(void)setDefaults:(NSDictionary<NSString *,NSObject *> * _Nullable)defaultConfig namespace:(NSString * _Nullable)aNamespace;
		[Export("setDefaults:namespace:")]
		void SetDefaults([NullAllowed] NSDictionary<NSString, NSObject> defaultConfig, [NullAllowed] string aNamespace);

		// -(void)setDefaultsFromPlistFileName:(NSString * _Nullable)fileName;
		[Export("setDefaultsFromPlistFileName:")]
		void SetDefaultsFromPlistFileName([NullAllowed] string fileName);

		// -(void)setDefaultsFromPlistFileName:(NSString * _Nullable)fileName namespace:(NSString * _Nullable)aNamespace;
		[Export("setDefaultsFromPlistFileName:namespace:")]
		void SetDefaultsFromPlistFileName([NullAllowed] string fileName, [NullAllowed] string aNamespace);

		// -(FIRRemoteConfigValue * _Nullable)defaultValueForKey:(NSString * _Nullable)key namespace:(NSString * _Nullable)aNamespace;
		[Export("defaultValueForKey:namespace:")]
		[return: NullAllowed]
		FIRRemoteConfigValue DefaultValueForKey([NullAllowed] string key, [NullAllowed] string aNamespace);
	}
}

