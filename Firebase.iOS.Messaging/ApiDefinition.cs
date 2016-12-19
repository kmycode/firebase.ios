using System;

using ObjCRuntime;
using Foundation;
using UIKit;

namespace Firebase.iOS.Messaging
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

namespace Firebase.iOS.Messaging
{
	// typedef void (^FIRMessagingConnectCompletion)(NSError * _Nullable);
	delegate void FIRMessagingConnectCompletion([NullAllowed] NSError arg0);

	//[Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull FIRMessagingSendSuccessNotification;
		[Static]
		[Field("FIRMessagingSendSuccessNotification", "__Internal")]
		NSString FIRMessagingSendSuccessNotification { get; }

		// extern NSString *const _Nonnull FIRMessagingSendErrorNotification;
		[Static]
		[Field("FIRMessagingSendErrorNotification", "__Internal")]
		NSString FIRMessagingSendErrorNotification { get; }

		// extern NSString *const _Nonnull FIRMessagingMessagesDeletedNotification;
		[Static]
		[Field("FIRMessagingMessagesDeletedNotification", "__Internal")]
		NSString FIRMessagingMessagesDeletedNotification { get; }
	}

	// @interface FIRMessagingMessageInfo : NSObject
	[BaseType(typeof(NSObject))]
	interface FIRMessagingMessageInfo
	{
		// @property (readonly, assign, nonatomic) FIRMessagingMessageStatus status;
		[Export("status", ArgumentSemantic.Assign)]
		FIRMessagingMessageStatus Status { get; }
	}

	// @interface FIRMessaging : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface FIRMessaging
	{
		// +(instancetype _Nonnull)messaging;
		[Static]
		[Export("messaging")]
		FIRMessaging Messaging();

		// -(void)connectWithCompletion:(FIRMessagingConnectCompletion _Nonnull)handler;
		[Export("connectWithCompletion:")]
		void ConnectWithCompletion(FIRMessagingConnectCompletion handler);

		// -(void)disconnect;
		[Export("disconnect")]
		void Disconnect();

		// -(void)subscribeToTopic:(NSString * _Nonnull)topic;
		[Export("subscribeToTopic:")]
		void SubscribeToTopic(string topic);

		// -(void)unsubscribeFromTopic:(NSString * _Nonnull)topic;
		[Export("unsubscribeFromTopic:")]
		void UnsubscribeFromTopic(string topic);

		// -(void)sendMessage:(NSDictionary * _Nonnull)message to:(NSString * _Nonnull)receiver withMessageID:(NSString * _Nonnull)messageID timeToLive:(int64_t)ttl;
		[Export("sendMessage:to:withMessageID:timeToLive:")]
		void SendMessage(NSDictionary message, string receiver, string messageID, long ttl);

		// -(FIRMessagingMessageInfo * _Nonnull)appDidReceiveMessage:(NSDictionary * _Nonnull)message;
		[Export("appDidReceiveMessage:")]
		FIRMessagingMessageInfo AppDidReceiveMessage(NSDictionary message);
	}
}

