using OpenCvSharp.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
{
	public class Window : DisposableObject
	{
		internal static Dictionary<string, Window> Windows = new Dictionary<string, Window>();

		private static uint windowCount = 0u;

		private string name;

		private Mat image;

		private CvMouseCallback mouseCallback;

		private readonly Dictionary<string, CvTrackbar> trackbars;

		private ScopedGCHandle callbackHandle;

		private bool disposed;

		public Mat Image
		{
			get
			{
				return image;
			}
			set
			{
				ShowImage(value);
			}
		}

		public string Name
		{
			get
			{
				return name;
			}
			private set
			{
				name = value;
			}
		}

		public IntPtr Handle => OpenCvSharp.NativeMethods.cvGetWindowHandle(name);

		internal CvMouseCallback MouseCallback
		{
			get
			{
				return mouseCallback;
			}
			set
			{
				if (callbackHandle != null && callbackHandle.IsAllocated)
				{
					callbackHandle.Dispose();
				}
				mouseCallback = value;
				callbackHandle = new ScopedGCHandle(mouseCallback, GCHandleType.Normal);
			}
		}

		public static bool HasQt => OpenCvSharp.NativeMethods.HasQt;

		public event CvMouseCallback OnMouseCallback
		{
			add
			{
				if (value == null)
				{
					throw new ArgumentNullException();
				}
				if (callbackHandle != null && callbackHandle.IsAllocated)
				{
					callbackHandle.Dispose();
				}
				mouseCallback = (CvMouseCallback)Delegate.Combine(mouseCallback, value);
				callbackHandle = new ScopedGCHandle(mouseCallback, GCHandleType.Normal);
				NativeMethods.highgui_setMouseCallback(name, mouseCallback, IntPtr.Zero);
			}
			remove
			{
				if (value == null)
				{
					throw new ArgumentNullException();
				}
				if (callbackHandle != null && callbackHandle.IsAllocated)
				{
					callbackHandle.Dispose();
				}
				mouseCallback = (CvMouseCallback)Delegate.Remove(mouseCallback, value);
				callbackHandle = new ScopedGCHandle(mouseCallback, GCHandleType.Normal);
				NativeMethods.highgui_setMouseCallback(name, mouseCallback, IntPtr.Zero);
			}
		}

		public Window()
			: this(DefaultName(), WindowMode.AutoSize, null)
		{
		}

		public Window(Mat image)
			: this(DefaultName(), WindowMode.AutoSize, image)
		{
		}

		public Window(WindowMode flags, Mat image)
			: this(DefaultName(), flags, image)
		{
		}

		public Window(string name)
			: this(name, WindowMode.AutoSize, null)
		{
		}

		public Window(string name, WindowMode flags)
			: this(name, flags, null)
		{
		}

		public Window(string name, Mat image)
			: this(name, WindowMode.AutoSize, image)
		{
		}

		public Window(string name, WindowMode flags, Mat image)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			this.name = name;
			NativeMethods.highgui_namedWindow(name, (int)flags);
			this.image = image;
			ShowImage(image);
			trackbars = new Dictionary<string, CvTrackbar>();
			if (!Windows.ContainsKey(name))
			{
				Windows.Add(name, this);
			}
			callbackHandle = null;
		}

		private static string DefaultName()
		{
			return $"window{windowCount++}";
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				try
				{
					if (disposing)
					{
						foreach (KeyValuePair<string, CvTrackbar> trackbar in trackbars)
						{
							if (trackbar.Value != null)
							{
								trackbar.Value.Dispose();
							}
						}
						if (Windows.ContainsKey("name"))
						{
							Windows.Remove(name);
						}
						if (callbackHandle != null && callbackHandle.IsAllocated)
						{
							callbackHandle.Dispose();
						}
					}
					NativeMethods.highgui_destroyWindow(name);
					disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		public void Close()
		{
			Dispose(disposing: true);
		}

		public static void DestroyAllWindows()
		{
			foreach (KeyValuePair<string, Window> window in Windows)
			{
				Window value = window.Value;
				if (value != null && !value.IsDisposed)
				{
					NativeMethods.highgui_destroyWindow(value.name);
					foreach (KeyValuePair<string, CvTrackbar> trackbar in value.trackbars)
					{
						if (trackbar.Value != null)
						{
							trackbar.Value.Dispose();
						}
					}
				}
			}
			Windows.Clear();
			NativeMethods.highgui_destroyAllWindows();
		}

		public CvTrackbar CreateTrackbar(string name, CvTrackbarCallback callback)
		{
			CvTrackbar cvTrackbar = new CvTrackbar(name, this.name, callback);
			trackbars.Add(name, cvTrackbar);
			return cvTrackbar;
		}

		public CvTrackbar CreateTrackbar(string name, int value, int max, CvTrackbarCallback callback)
		{
			CvTrackbar cvTrackbar = new CvTrackbar(name, this.name, value, max, callback);
			trackbars.Add(name, cvTrackbar);
			return cvTrackbar;
		}

		public CvTrackbar CreateTrackbar2(string name, int value, int max, CvTrackbarCallback2 callback, object userdata)
		{
			CvTrackbar cvTrackbar = new CvTrackbar(name, this.name, value, max, callback, userdata);
			trackbars.Add(name, cvTrackbar);
			return cvTrackbar;
		}

		public void DisplayOverlay(string text, int delayms)
		{
			Cv.DisplayOverlay(name, text, delayms);
		}

		public void DisplayStatusBar(string text, int delayms)
		{
			Cv.DisplayStatusBar(name, text, delayms);
		}

		public WindowPropertyValue GetProperty(WindowProperty propId)
		{
			return Cv2.GetWindowProperty(name, propId);
		}

		public void LoadWindowParameters()
		{
			Cv.LoadWindowParameters(name);
		}

		public void Move(int x, int y)
		{
			NativeMethods.highgui_moveWindow(name, x, y);
		}

		public void Resize(int width, int height)
		{
			NativeMethods.highgui_resizeWindow(name, width, height);
		}

		public void SaveWindowParameters()
		{
			Cv.SaveWindowParameters(name);
		}

		public void SetProperty(WindowProperty propId, WindowPropertyValue propValue)
		{
			Cv2.SetWindowProperty(name, propId, propValue);
		}

		public void SetProperty(WindowProperty propId, double propValue)
		{
			Cv2.SetWindowProperty(name, propId, propValue);
		}

		public void ShowImage(Mat img)
		{
			if (img != null)
			{
				image = img;
				NativeMethods.highgui_imshow(name, img.CvPtr);
			}
		}

		public static int WaitKey()
		{
			return NativeMethods.highgui_waitKey(0);
		}

		public static int WaitKey(int delay)
		{
			return NativeMethods.highgui_waitKey(delay);
		}

		public static void ShowImages(params Mat[] images)
		{
			if (images == null)
			{
				throw new ArgumentNullException("images");
			}
			if (images.Length != 0)
			{
				List<Window> list = new List<Window>();
				foreach (Mat mat in images)
				{
					list.Add(new Window(mat));
				}
				WaitKey();
				foreach (Window item in list)
				{
					item.Close();
				}
			}
		}

		public static void ShowImages(IEnumerable<Mat> images, IEnumerable<string> names)
		{
			if (images == null)
			{
				throw new ArgumentNullException("images");
			}
			if (names == null)
			{
				throw new ArgumentNullException("names");
			}
			Mat[] array = EnumerableEx.ToArray(images);
			string[] array2 = EnumerableEx.ToArray(names);
			if (array.Length != 0)
			{
				if (array2.Length < array.Length)
				{
					throw new ArgumentException("names.Length < images.Length");
				}
				List<Window> list = new List<Window>();
				for (int i = 0; i < array.Length; i++)
				{
					list.Add(new Window(array2[i], array[i]));
				}
				Cv.WaitKey();
				foreach (Window item in list)
				{
					item.Close();
				}
			}
		}

		public static Window GetWindowByName(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			if (Windows.ContainsKey(name))
			{
				return Windows[name];
			}
			return null;
		}
	}
}
