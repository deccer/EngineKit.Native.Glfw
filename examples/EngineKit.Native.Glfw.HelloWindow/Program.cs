namespace EngineKit.Native.Glfw.HelloWindow;

internal class Program
{
    public static void Main(string[] args)
    {
        if (!Glfw.Init())
        {
            return;
        }

        Glfw.SetErrorCallback((errorCode, errorDescription) => { Console.WriteLine($"{errorCode} - {errorDescription}"); });

        var primaryMonitor = Glfw.GetPrimaryMonitor();
        var primaryMonitorResolution = Glfw.GetVideoMode(primaryMonitor);

        var screenWidth = primaryMonitorResolution.Width;
        var screenHeight = primaryMonitorResolution.Height;

        var windowWidth = (int)(screenWidth * 0.8f);
        var windowHeight = (int)(screenHeight * 0.8f);

        var windowHandle = Glfw.CreateWindow(
            windowWidth,
            windowHeight,
            "HelloWindow",
            IntPtr.Zero,
            IntPtr.Zero);
        if (windowHandle == IntPtr.Zero)
        {
            return;
        }

        Glfw.SetWindowPos(
            windowHandle,
            screenWidth / 2 - windowWidth / 2,
            screenHeight / 2 - windowHeight / 2);

        while (!Glfw.ShouldWindowClose(windowHandle))
        {
            Glfw.PollEvents();

            Glfw.SwapBuffers(windowHandle);
        }

        Glfw.Terminate();
    }
}