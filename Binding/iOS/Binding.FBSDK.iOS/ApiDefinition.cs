using System;

using ObjCRuntime;
using Foundation;
using UIKit;

namespace Stormlion.Facebook.iOS.Binding
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

    [BaseType(typeof(NSObject))]
    interface FBSDKLoginManager
    {
        [Export("logOut")]
        void LogOut();

        [Export("logInWithReadPermissions:fromViewController:handler:")]
        void LogInWithReadPermissions(string[] permissions, UIViewController fromViewController, FBSDKLoginManagerRequestTokenHandler handler);

        [Export("logInWithPublishPermissions:fromViewController:handler:")]
        void LogInWithPublishPermissions(string[] permissions, UIViewController fromViewController, FBSDKLoginManagerRequestTokenHandler handler);
    }

    [BaseType(typeof(NSObject))]
    interface FBSDKLoginManagerLoginResult
    {
        [Export("token")]
        FBSDKAccessToken Token { get; }

        [Export("isCancelled")]
        bool IsCancelled { get; }
    }

    delegate void FBSDKLoginManagerRequestTokenHandler(FBSDKLoginManagerLoginResult result, NSError error);

    [BaseType(typeof(NSObject))]
    interface FBSDKAccessToken
    {
        [Static]
        [Export ("currentAccessToken")]
        FBSDKAccessToken Current { get; }

        [Export("hasGranted:")]
        bool HasGranted(string permission);


        [Export("permissions", ArgumentSemantic.Copy)]
        NSSet Permissions { get; }

        [Export("declinedPermissions", ArgumentSemantic.Copy)]
        NSSet DeclinedPermissions { get; }

        [Export("tokenString")]
        string TokenString { get; }
    }

    [BaseType(typeof(NSObject))]
    interface FBSDKApplicationDelegate
    {
        [Static]
        [Export("sharedInstance")]
        FBSDKApplicationDelegate Instance { get; }

        // -(BOOL)application:(UIApplication *)application openURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication annotation:(id)annotation;
        [Export("application:openURL:sourceApplication:annotation:")]
        bool OpenURL(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation);

        // -(BOOL)application:(UIApplication *)application openURL:(NSURL *)url options:(NSDictionary<UIApplicationOpenURLOptionsKey,id> *)options;
        [Export("application:openURL:options:")]
        //bool OpenURL(UIApplication application, NSUrl url, NSDictionary<NSString, NSObject> options);
        bool OpenURL(UIApplication application, NSUrl url, [NullAllowed]NSDictionary options);

        // -(BOOL)application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions;
        [Export("application:didFinishLaunchingWithOptions:")]
        bool DidFinishLaunching(UIApplication application, [NullAllowed]NSDictionary launchOptions);
    }

    // @interface FBSDKGraphRequest : NSObject
    [BaseType(typeof(NSObject))]
    interface FBSDKGraphRequest
    {
        // -(instancetype)initWithGraphPath:(NSString *)graphPath parameters:(NSDictionary *)parameters;
        [Export("initWithGraphPath:parameters:")]
        IntPtr Constructor(string graphPath, NSDictionary parameters);

        // -(instancetype)initWithGraphPath:(NSString *)graphPath parameters:(NSDictionary *)parameters HTTPMethod:(NSString *)HTTPMethod;
        [Export("initWithGraphPath:parameters:HTTPMethod:")]
        IntPtr Constructor(string graphPath, NSDictionary parameters, string HTTPMethod);

        // -(instancetype)initWithGraphPath:(NSString *)graphPath parameters:(NSDictionary *)parameters tokenString:(NSString *)tokenString version:(NSString *)version HTTPMethod:(NSString *)HTTPMethod __attribute__((objc_designated_initializer));
        [Export("initWithGraphPath:parameters:tokenString:version:HTTPMethod:")]
        [DesignatedInitializer]
        IntPtr Constructor(string graphPath, [NullAllowed]NSDictionary parameters, string tokenString, [NullAllowed]string version, string HTTPMethod);

        // @property (readonly, nonatomic, strong) NSMutableDictionary * parameters;
        [Export("parameters", ArgumentSemantic.Strong)]
        NSMutableDictionary Parameters { get; }

        // @property (readonly, copy, nonatomic) NSString * tokenString;
        [Export("tokenString")]
        string TokenString { get; }

        // @property (readonly, copy, nonatomic) NSString * graphPath;
        [Export("graphPath")]
        string GraphPath { get; }

        // @property (readonly, copy, nonatomic) NSString * HTTPMethod;
        [Export("HTTPMethod")]
        string HTTPMethod { get; }

        // @property (readonly, copy, nonatomic) NSString * version;
        [Export("version")]
        string Version { get; }

        // -(void)setGraphErrorRecoveryDisabled:(BOOL)disable;
        [Export("setGraphErrorRecoveryDisabled:")]
        void SetGraphErrorRecoveryDisabled(bool disable);

        // -(FBSDKGraphRequestConnection *)startWithCompletionHandler:(FBSDKGraphRequestHandler)handler;
        [Export("startWithCompletionHandler:")]
        FBSDKGraphRequestConnection StartWithCompletionHandler(FBSDKGraphRequestHandler handler);
    }

    // typedef void (^FBSDKGraphRequestHandler)(FBSDKGraphRequestConnection *, id, NSError *);
    delegate void FBSDKGraphRequestHandler(FBSDKGraphRequestConnection connection, NSObject result, NSError error);

    // @interface FBSDKGraphRequestConnection : NSObject
    [BaseType(typeof(NSObject))]
    interface FBSDKGraphRequestConnection
    {
        //[Wrap("WeakDelegate")]
        //FBSDKGraphRequestConnectionDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<FBSDKGraphRequestConnectionDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic) NSTimeInterval timeout;
        [Export("timeout")]
        double Timeout { get; set; }

        // @property (readonly, retain, nonatomic) NSHTTPURLResponse * URLResponse;
        [Export("URLResponse", ArgumentSemantic.Retain)]
        NSHttpUrlResponse URLResponse { get; }

        // +(void)setDefaultConnectionTimeout:(NSTimeInterval)defaultConnectionTimeout;
        [Static]
        [Export("setDefaultConnectionTimeout:")]
        void SetDefaultConnectionTimeout(double defaultConnectionTimeout);

        // -(void)addRequest:(FBSDKGraphRequest *)request completionHandler:(FBSDKGraphRequestHandler)handler;
        [Export("addRequest:completionHandler:")]
        void AddRequest(FBSDKGraphRequest request, FBSDKGraphRequestHandler handler);

        // -(void)addRequest:(FBSDKGraphRequest *)request completionHandler:(FBSDKGraphRequestHandler)handler batchEntryName:(NSString *)name;
        [Export("addRequest:completionHandler:batchEntryName:")]
        void AddRequest(FBSDKGraphRequest request, FBSDKGraphRequestHandler handler, string name);

        // -(void)addRequest:(FBSDKGraphRequest *)request completionHandler:(FBSDKGraphRequestHandler)handler batchParameters:(NSDictionary *)batchParameters;
        [Export("addRequest:completionHandler:batchParameters:")]
        void AddRequest(FBSDKGraphRequest request, FBSDKGraphRequestHandler handler, NSDictionary batchParameters);

        // -(void)cancel;
        [Export("cancel")]
        void Cancel();

        // -(void)start;
        [Export("start")]
        void Start();

        // -(void)setDelegateQueue:(NSOperationQueue *)queue;
        [Export("setDelegateQueue:")]
        void SetDelegateQueue(NSOperationQueue queue);

        // -(void)overrideVersionPartWith:(NSString *)version;
        [Export("overrideVersionPartWith:")]
        void OverrideVersionPartWith(string version);
    }

}

