using System;

using CoreFoundation;
using ObjCRuntime;
using Foundation;
using UIKit;

namespace Firebase.iOS.Storage
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

namespace Firebase.iOS.Analytics
{
	interface FIRApp { }
}

namespace Firebase.iOS.Storage
{
	using Firebase.iOS.Analytics;

	// typedef void (^FIRStorageVoidDataError)(NSData * _Nullable, NSError * _Nullable);
	delegate void FIRStorageVoidDataError([NullAllowed] NSData arg0, [NullAllowed] NSError arg1);

	// typedef void (^FIRStorageVoidError)(NSError * _Nullable);
	delegate void FIRStorageVoidError([NullAllowed] NSError arg0);

	// typedef void (^FIRStorageVoidMetadata)(FIRStorageMetadata * _Nullable);
	delegate void FIRStorageVoidMetadata([NullAllowed] FIRStorageMetadata arg0);

	// typedef void (^FIRStorageVoidMetadataError)(FIRStorageMetadata * _Nullable, NSError * _Nullable);
	delegate void FIRStorageVoidMetadataError([NullAllowed] FIRStorageMetadata arg0, [NullAllowed] NSError arg1);

	// typedef void (^FIRStorageVoidSnapshot)(FIRStorageTaskSnapshot * _Nonnull);
	delegate void FIRStorageVoidSnapshot(FIRStorageTaskSnapshot arg0);

	// typedef void (^FIRStorageVoidURLError)(NSURL * _Nullable, NSError * _Nullable);
	delegate void FIRStorageVoidURLError([NullAllowed] NSUrl arg0, [NullAllowed] NSError arg1);

	//[Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull FIRStorageErrorDomain;
		[Static]
		[Field("FIRStorageErrorDomain", "__Internal")]
		NSString FIRStorageErrorDomain { get; }
	}

	// @interface FIRStorage : NSObject
	[BaseType(typeof(NSObject))]
	interface FIRStorage
	{
		// +(instancetype _Nonnull)storage;
		[Static]
		[Export("storage")]
		FIRStorage Storage { get; }

		// +(instancetype _Nonnull)storageForApp:(FIRApp * _Nonnull)app;
		[Static]
		[Export("storageForApp:")]
		FIRStorage StorageForApp(FIRApp app);

		// @property (readonly, nonatomic, strong) FIRApp * _Nonnull app;
		[Export("app", ArgumentSemantic.Strong)]
		FIRApp App { get; }

		// @property NSTimeInterval maxUploadRetryTime;
		[Export("maxUploadRetryTime")]
		double MaxUploadRetryTime { get; set; }

		// @property NSTimeInterval maxDownloadRetryTime;
		[Export("maxDownloadRetryTime")]
		double MaxDownloadRetryTime { get; set; }

		// @property NSTimeInterval maxOperationRetryTime;
		[Export("maxOperationRetryTime")]
		double MaxOperationRetryTime { get; set; }

		// @property (nonatomic, strong) dispatch_queue_t _Nonnull callbackQueue;
		[Export("callbackQueue", ArgumentSemantic.Strong)]
		DispatchQueue CallbackQueue { get; set; }

		// -(FIRStorageReference * _Nonnull)reference;
		[Export("reference")]
		//[Verify(MethodToProperty)]
		FIRStorageReference Reference { get; }

		// -(FIRStorageReference * _Nonnull)referenceForURL:(NSString * _Nonnull)string;
		[Export("referenceForURL:")]
		FIRStorageReference ReferenceForURL(string @string);

		// -(FIRStorageReference * _Nonnull)referenceWithPath:(NSString * _Nonnull)string;
		[Export("referenceWithPath:")]
		FIRStorageReference ReferenceWithPath(string @string);
	}

	// @interface FIRStorageMetadata : NSObject <NSCopying>
	[BaseType(typeof(NSObject))]
	interface FIRStorageMetadata : INSCopying
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull bucket;
		[Export("bucket")]
		string Bucket { get; }

		// @property (copy, nonatomic) NSString * _Nullable cacheControl;
		[NullAllowed, Export("cacheControl")]
		string CacheControl { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable contentDisposition;
		[NullAllowed, Export("contentDisposition")]
		string ContentDisposition { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable contentEncoding;
		[NullAllowed, Export("contentEncoding")]
		string ContentEncoding { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable contentLanguage;
		[NullAllowed, Export("contentLanguage")]
		string ContentLanguage { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable contentType;
		[NullAllowed, Export("contentType")]
		string ContentType { get; set; }

		// @property (readonly) int64_t generation;
		[Export("generation")]
		long Generation { get; }

		// @property (copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable customMetadata;
		[NullAllowed, Export("customMetadata", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> CustomMetadata { get; set; }

		// @property (readonly) int64_t metageneration;
		[Export("metageneration")]
		long Metageneration { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable path;
		[NullAllowed, Export("path")]
		string Path { get; }

		// @property (readonly) int64_t size;
		[Export("size")]
		long Size { get; }

		// @property (readonly, copy, nonatomic) NSDate * _Nullable timeCreated;
		[NullAllowed, Export("timeCreated", ArgumentSemantic.Copy)]
		NSDate TimeCreated { get; }

		// @property (readonly, copy, nonatomic) NSDate * _Nullable updated;
		[NullAllowed, Export("updated", ArgumentSemantic.Copy)]
		NSDate Updated { get; }

		// @property (readonly, nonatomic, strong) FIRStorageReference * _Nullable storageReference;
		[NullAllowed, Export("storageReference", ArgumentSemantic.Strong)]
		FIRStorageReference StorageReference { get; }

		// @property (readonly, nonatomic, strong) NSArray<NSURL *> * _Nullable downloadURLs;
		[NullAllowed, Export("downloadURLs", ArgumentSemantic.Strong)]
		NSUrl[] DownloadURLs { get; }

		// -(instancetype _Nullable)initWithDictionary:(NSDictionary * _Nonnull)dictionary __attribute__((objc_designated_initializer));
		[Export("initWithDictionary:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSDictionary dictionary);

		// -(NSDictionary * _Nonnull)dictionaryRepresentation;
		[Export("dictionaryRepresentation")]
		//[Verify(MethodToProperty)]
		NSDictionary DictionaryRepresentation { get; }

		// @property (readonly, getter = isFile) BOOL file;
		[Export("file")]
		bool File { [Bind("isFile")] get; }

		// @property (readonly, getter = isFolder) BOOL folder;
		[Export("folder")]
		bool Folder { [Bind("isFolder")] get; }

		// -(NSURL * _Nullable)downloadURL;
		[NullAllowed, Export("downloadURL")]
		//[Verify(MethodToProperty)]
		NSUrl DownloadURL { get; }
	}

	// @interface FIRStorageTask : NSObject
	[BaseType(typeof(NSObject))]
	interface FIRStorageTask
	{
		// @property (readonly, nonatomic, strong) FIRStorageTaskSnapshot * _Nonnull snapshot;
		[Export("snapshot", ArgumentSemantic.Strong)]
		FIRStorageTaskSnapshot Snapshot { get; }
	}

	// @protocol FIRStorageTaskManagement <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface FIRStorageTaskManagement
	{
		// @required -(void)enqueue;
		[Abstract]
		[Export("enqueue")]
		void Enqueue();

		// @optional -(void)pause;
		[Export("pause")]
		void Pause();

		// @optional -(void)cancel;
		[Export("cancel")]
		void Cancel();

		// @optional -(void)resume;
		[Export("resume")]
		void Resume();
	}

	// @interface FIRStorageObservableTask : FIRStorageTask
	[BaseType(typeof(FIRStorageTask))]
	interface FIRStorageObservableTask
	{
		// -(FIRStorageHandle _Nonnull)observeStatus:(FIRStorageTaskStatus)status handler:(void (^ _Nonnull)(FIRStorageTaskSnapshot * _Nonnull))handler;
		[Export("observeStatus:handler:")]
		string ObserveStatus(FIRStorageTaskStatus status, Action<FIRStorageTaskSnapshot> handler);

		// -(void)removeObserverWithHandle:(FIRStorageHandle _Nonnull)handle;
		[Export("removeObserverWithHandle:")]
		void RemoveObserverWithHandle(string handle);

		// -(void)removeAllObserversForStatus:(FIRStorageTaskStatus)status;
		[Export("removeAllObserversForStatus:")]
		void RemoveAllObserversForStatus(FIRStorageTaskStatus status);

		// -(void)removeAllObservers;
		[Export("removeAllObservers")]
		void RemoveAllObservers();
	}

	interface IFIRStorageTaskManagement { }

	// @interface FIRStorageDownloadTask : FIRStorageObservableTask <FIRStorageTaskManagement>
	[BaseType(typeof(FIRStorageObservableTask))]
	interface FIRStorageDownloadTask : IFIRStorageTaskManagement
	{
	}

	// @interface FIRStorageUploadTask : FIRStorageObservableTask <FIRStorageTaskManagement>
	[BaseType(typeof(FIRStorageObservableTask))]
	interface FIRStorageUploadTask : IFIRStorageTaskManagement
	{
	}

	// @interface FIRStorageReference : NSObject
	[BaseType(typeof(NSObject))]
	interface FIRStorageReference
	{
		// @property (readonly, nonatomic) FIRStorage * _Nonnull storage;
		[Export("storage")]
		FIRStorage Storage { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull bucket;
		[Export("bucket")]
		string Bucket { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull fullPath;
		[Export("fullPath")]
		string FullPath { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull name;
		[Export("name")]
		string Name { get; }

		// -(FIRStorageReference * _Nonnull)root;
		[Export("root")]
		//[Verify(MethodToProperty)]
		FIRStorageReference Root { get; }

		// -(FIRStorageReference * _Nullable)parent;
		[NullAllowed, Export("parent")]
		//[Verify(MethodToProperty)]
		FIRStorageReference Parent { get; }

		// -(FIRStorageReference * _Nonnull)child:(NSString * _Nonnull)path;
		[Export("child:")]
		FIRStorageReference Child(string path);

		// -(FIRStorageUploadTask * _Nonnull)putData:(NSData * _Nonnull)uploadData;
		[Export("putData:")]
		FIRStorageUploadTask PutData(NSData uploadData);

		// -(FIRStorageUploadTask * _Nonnull)putData:(NSData * _Nonnull)uploadData metadata:(FIRStorageMetadata * _Nullable)metadata;
		[Export("putData:metadata:")]
		FIRStorageUploadTask PutData(NSData uploadData, [NullAllowed] FIRStorageMetadata metadata);

		// -(FIRStorageUploadTask * _Nonnull)putData:(NSData * _Nonnull)uploadData metadata:(FIRStorageMetadata * _Nullable)metadata completion:(void (^ _Nullable)(FIRStorageMetadata * _Nullable, NSError * _Nullable))completion;
		[Export("putData:metadata:completion:")]
		FIRStorageUploadTask PutData(NSData uploadData, [NullAllowed] FIRStorageMetadata metadata, [NullAllowed] Action<FIRStorageMetadata, NSError> completion);

		// -(FIRStorageUploadTask * _Nonnull)putFile:(NSURL * _Nonnull)fileURL;
		[Export("putFile:")]
		FIRStorageUploadTask PutFile(NSUrl fileURL);

		// -(FIRStorageUploadTask * _Nonnull)putFile:(NSURL * _Nonnull)fileURL metadata:(FIRStorageMetadata * _Nullable)metadata;
		[Export("putFile:metadata:")]
		FIRStorageUploadTask PutFile(NSUrl fileURL, [NullAllowed] FIRStorageMetadata metadata);

		// -(FIRStorageUploadTask * _Nonnull)putFile:(NSURL * _Nonnull)fileURL metadata:(FIRStorageMetadata * _Nullable)metadata completion:(void (^ _Nullable)(FIRStorageMetadata * _Nullable, NSError * _Nullable))completion;
		[Export("putFile:metadata:completion:")]
		FIRStorageUploadTask PutFile(NSUrl fileURL, [NullAllowed] FIRStorageMetadata metadata, [NullAllowed] Action<FIRStorageMetadata, NSError> completion);

		// -(FIRStorageDownloadTask * _Nonnull)dataWithMaxSize:(int64_t)size completion:(void (^ _Nonnull)(NSData * _Nullable, NSError * _Nullable))completion;
		[Export("dataWithMaxSize:completion:")]
		FIRStorageDownloadTask DataWithMaxSize(long size, Action<NSData, NSError> completion);

		// -(void)downloadURLWithCompletion:(void (^ _Nonnull)(NSURL * _Nullable, NSError * _Nullable))completion;
		[Export("downloadURLWithCompletion:")]
		void DownloadURLWithCompletion(Action<NSUrl, NSError> completion);

		// -(FIRStorageDownloadTask * _Nonnull)writeToFile:(NSURL * _Nonnull)fileURL;
		[Export("writeToFile:")]
		FIRStorageDownloadTask WriteToFile(NSUrl fileURL);

		// -(FIRStorageDownloadTask * _Nonnull)writeToFile:(NSURL * _Nonnull)fileURL completion:(void (^ _Nullable)(NSURL * _Nullable, NSError * _Nullable))completion;
		[Export("writeToFile:completion:")]
		FIRStorageDownloadTask WriteToFile(NSUrl fileURL, [NullAllowed] Action<NSUrl, NSError> completion);

		// -(void)metadataWithCompletion:(void (^ _Nonnull)(FIRStorageMetadata * _Nullable, NSError * _Nullable))completion;
		[Export("metadataWithCompletion:")]
		void MetadataWithCompletion(Action<FIRStorageMetadata, NSError> completion);

		// -(void)updateMetadata:(FIRStorageMetadata * _Nonnull)metadata completion:(void (^ _Nullable)(FIRStorageMetadata * _Nullable, NSError * _Nullable))completion;
		[Export("updateMetadata:completion:")]
		void UpdateMetadata(FIRStorageMetadata metadata, [NullAllowed] Action<FIRStorageMetadata, NSError> completion);

		// -(void)deleteWithCompletion:(void (^ _Nullable)(NSError * _Nullable))completion;
		[Export("deleteWithCompletion:")]
		void DeleteWithCompletion([NullAllowed] Action<NSError> completion);
	}

	// @interface FIRStorageTaskSnapshot : NSObject
	[BaseType(typeof(NSObject))]
	interface FIRStorageTaskSnapshot
	{
		// @property (readonly, copy, nonatomic) __kindof FIRStorageTask * _Nonnull task;
		[Export("task", ArgumentSemantic.Copy)]
		FIRStorageTask Task { get; }

		// @property (readonly, copy, nonatomic) FIRStorageMetadata * _Nullable metadata;
		[NullAllowed, Export("metadata", ArgumentSemantic.Copy)]
		FIRStorageMetadata Metadata { get; }

		// @property (readonly, copy, nonatomic) FIRStorageReference * _Nonnull reference;
		[Export("reference", ArgumentSemantic.Copy)]
		FIRStorageReference Reference { get; }

		// @property (readonly, nonatomic, strong) NSProgress * _Nullable progress;
		[NullAllowed, Export("progress", ArgumentSemantic.Strong)]
		NSProgress Progress { get; }

		// @property (readonly, copy, nonatomic) NSError * _Nullable error;
		[NullAllowed, Export("error", ArgumentSemantic.Copy)]
		NSError Error { get; }
	}

	//[Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const unsigned char *const FirebaseStorageVersionString;
		[Static]
		[Field("FirebaseStorageVersionString", "__Internal")]
		unsafe byte* FirebaseStorageVersionString { get; }
	}
}

