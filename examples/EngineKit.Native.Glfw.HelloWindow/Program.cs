namespace EngineKit.Native.Glfw.HelloWindow;

internal static class Program
{
    private static Glfw.CursorPositionCallback? _cursorPositionCallback;

    public static void Main(string[] args)
    {
        if (!Glfw.Init())
        {
            return;
        }

        _cursorPositionCallback = CursorPositionCallback;

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

        if (Glfw.IsRawMouseMotionSupported())
        {
            Glfw.SetInputMode(windowHandle, Glfw.InputMode.RawMouseMotion, Glfw.True);
        }

        Glfw.SetWindowPos(
            windowHandle,
            screenWidth / 2 - windowWidth / 2,
            screenHeight / 2 - windowHeight / 2);

        Glfw.SetCursorPositionCallback(windowHandle, _cursorPositionCallback);

        while (!Glfw.ShouldWindowClose(windowHandle))
        {
            Glfw.PollEvents();
            if (Glfw.GetKeyPressed(windowHandle, Glfw.Key.KeyEscape))
            {
                Glfw.SetWindowShouldClose(windowHandle, Glfw.True);
            }
            if (Glfw.GetKeyPressed(windowHandle, Glfw.Key.KeyF5))
            {
                Glfw.SetInputMode(windowHandle, Glfw.InputMode.Cursor, Glfw.CursorHidden);
            }
            if (Glfw.GetKeyPressed(windowHandle, Glfw.Key.KeyF6))
            {
                Glfw.SetInputMode(windowHandle, Glfw.InputMode.Cursor, Glfw.CursorNormal);
            }

            Glfw.SwapBuffers(windowHandle);
        }

        Glfw.Terminate();
    }

    private static void CursorPositionCallback(IntPtr windowHandle, double x, double y)
    {
        Console.WriteLine($"X: {x:f2} Y: {y:f2}");
    }
}