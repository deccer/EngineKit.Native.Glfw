using System;
using System.Runtime.InteropServices;

namespace EngineKit.Native.Glfw;

public static unsafe partial class Glfw
{
    public static bool Init()
    {
        return _glfwInit() == 1;
    }

    public static void Terminate()
    {
        _glfwTerminate();
    }

    public static bool IsRawMouseMotionSupported()
    {
        return _glfwRawMouseMotionSupported();
    }

    public static void SetInputMode(
        IntPtr windowHandle,
        InputMode inputMode,
        int value)
    {
        _glfwSetInputMode(windowHandle, inputMode, value);
    }

    public static void GetCursorPos(
        IntPtr windowHandle,
        out int x,
        out int y)
    {
        double cursorPosX;
        double cursorPosY;
        _glfwGetCursorPos(windowHandle, &cursorPosX, &cursorPosY);
        x = (int)cursorPosX;
        y = (int)cursorPosY;
    }

    public static void SetCursorPos(
        IntPtr windowHandle,
        float x,
        float y)
    {
        _glfwSetCursorPos(windowHandle, x, y);
    }

    public static void WindowHint(
        WindowInitHint windowInitHint,
        bool value)
    {
        _glfwWindowHint((int)windowInitHint, value ? 1 : 0);
    }

    public static void WindowHint(
        WindowInitHint windowInitHint,
        int value)
    {
        _glfwWindowHint((int)windowInitHint, value);
    }

    public static void WindowHint(
        WindowInitHint windowInitHint,
        ClientApi clientApi)
    {
        _glfwWindowHint((int)windowInitHint, (int)clientApi);
    }

    public static void WindowHint(
        WindowOpenGLContextHint openglContextHint,
        int value)
    {
        _glfwWindowHint((int)openglContextHint, value);
    }

    public static void WindowHint(
        WindowOpenGLContextHint openglContextHint,
        bool value)
    {
        _glfwWindowHint((int)openglContextHint, value ? 1 : 0);
    }

    public static void WindowHint(
        WindowOpenGLContextHint openglContextHint,
        OpenGLProfile openGlProfile)
    {
        _glfwWindowHint((int)openglContextHint, (int)openGlProfile);
    }

    public static IntPtr CreateWindow(
        int width,
        int height,
        string title,
        IntPtr monitorHandle,
        IntPtr sharedHandle)
    {
        var titlePtr = Marshal.StringToHGlobalAnsi(title);
        var windowHandle = _glfwCreateWindow(
            width,
            height,
            titlePtr,
            monitorHandle,
            sharedHandle);
        Marshal.FreeHGlobal(titlePtr);
        return windowHandle;
    }

    public static void DestroyWindow(IntPtr windowHandle)
    {
        _glfwDestroyWindow(windowHandle);
    }

    public static bool ShouldWindowClose(IntPtr windowHandle)
    {
        return _glfwWindowShouldClose(windowHandle) == 1;
    }

    public static void SetWindowShouldClose(
        IntPtr windowHandle,
        int closeFlag)
    {
        _glfwSetWindowShouldClose(windowHandle, closeFlag);
    }

    public static void PollEvents()
    {
        _glfwPollEvents();
    }

    public static void WaitEventsTimeout(double timeout)
    {
        _glfwWaitEventsTimeout(timeout);
    }

    public static void SwapBuffers(IntPtr windowHandle)
    {
        _glfwSwapBuffers(windowHandle);
    }

    public static IntPtr GetProcAddress(string functionName)
    {
        var functionNamePtr = Marshal.StringToHGlobalAnsi(functionName);
        var functionAddress = _glfwGetProcAddress(functionNamePtr);
        Marshal.FreeHGlobal(functionNamePtr);

        return functionAddress;
    }

    public static void MakeContextCurrent(IntPtr windowHandle)
    {
        _glfwMakeContextCurrent(windowHandle);
    }

    public static void SwapInterval(int interval)
    {
        _glfwSwapInterval(interval);
    }

    public static void SetWindowPos(
        IntPtr windowHandle,
        int left,
        int top)
    {
        _glfwSetWindowPos(windowHandle, left, top);
    }

    public static void SetWindowSize(
        IntPtr windowHandle,
        int width,
        int height)
    {
        _glfwSetWindowSize(windowHandle, width, height);
    }

    public static IntPtr GetPrimaryMonitor()
    {
        return _glfwGetPrimaryMonitor();
    }

    public static VideoMode GetVideoMode(IntPtr monitorHandle)
    {
        var videoMode = _glfwGetVideoMode(monitorHandle);
        return Marshal.PtrToStructure<VideoMode>(videoMode);
    }

    public static void SetKeyCallback(
        IntPtr windowHandle,
        KeyCallback? keyCallback)
    {
        var keyCallbackPtr = keyCallback == null
            ? IntPtr.Zero
            : Marshal.GetFunctionPointerForDelegate(keyCallback);
        _glfwSetKeyCallback(windowHandle, keyCallbackPtr);
    }

    public static void SetCharCallback(
        IntPtr windowHandle,
        CharCallback? charCallback)
    {
        var charCallbackPtr = charCallback == null
            ? IntPtr.Zero
            : Marshal.GetFunctionPointerForDelegate(charCallback);
        _glfwSetCharCallback(windowHandle, charCallbackPtr);
    }

    public static void SetCursorPositionCallback(
        IntPtr windowHandle,
        CursorPositionCallback? cursorPositionCallback)
    {
        var cursorPositionCallbackPtr = cursorPositionCallback == null
            ? IntPtr.Zero
            : Marshal.GetFunctionPointerForDelegate(cursorPositionCallback);
        _glfwSetCursorPositionCallback(windowHandle, cursorPositionCallbackPtr);
    }

    public static void SetCursorEnterCallback(
        IntPtr windowHandle,
        CursorEnterCallback? cursorEnterCallback)
    {
        var cursorEnterCallbackPtr = cursorEnterCallback == null
            ? IntPtr.Zero
            : Marshal.GetFunctionPointerForDelegate(cursorEnterCallback);
        _glfwSetCursorEnterCallback(windowHandle, cursorEnterCallbackPtr);
    }

    public static void SetMouseButtonCallback(
        IntPtr windowHandle,
        MouseButtonCallback? mouseButtonCallback)
    {
        var mouseButtonCallbackPtr = mouseButtonCallback == null
            ? IntPtr.Zero
            : Marshal.GetFunctionPointerForDelegate(mouseButtonCallback);
        _glfwSetMouseButtonCallback(windowHandle, mouseButtonCallbackPtr);
    }

    public static void SetWindowSizeCallback(
        IntPtr windowHandle,
        WindowSizeCallback? windowSizeCallback)
    {
        var sizeWindowCallbackPtr = windowSizeCallback == null
            ? IntPtr.Zero
            : Marshal.GetFunctionPointerForDelegate(windowSizeCallback);
        _glfwSetWindowSizeCallback(windowHandle, sizeWindowCallbackPtr);
    }

    public static void SetFramebufferSizeCallback(
        IntPtr windowHandle,
        FramebufferSizeCallback? framebufferSizeCallback)
    {
        var framebufferSizeCallbackPtr = framebufferSizeCallback == null
            ? IntPtr.Zero
            : Marshal.GetFunctionPointerForDelegate(framebufferSizeCallback);
        _glfwSetFramebufferSizeCallback(windowHandle, framebufferSizeCallbackPtr);
    }

    public static float GetTime()
    {
        return (float)_glfwGetTime();
    }


    public static void GetFramebufferSize(
        IntPtr windowHandle,
        out int framebufferWidth,
        out int framebufferHeight)
    {
        int width;
        int height;
        _glfwGetFramebufferSize(windowHandle, &width, &height);
        framebufferWidth = width;
        framebufferHeight = height;
    }
}