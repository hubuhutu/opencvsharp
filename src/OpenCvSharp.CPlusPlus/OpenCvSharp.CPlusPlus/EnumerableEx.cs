using System;
using System.Collections;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
	internal static class EnumerableEx
	{
		public static IEnumerable<TResult> Select<TSource, TResult>(IEnumerable<TSource> enumerable, Func<TSource, TResult> selector)
		{
			if (enumerable == null)
			{
				throw new ArgumentNullException("enumerable");
			}
			if (selector == null)
			{
				throw new ArgumentNullException("selector");
			}
			foreach (TSource item in enumerable)
			{
				yield return selector(item);
			}
		}

		public static TResult[] SelectToArray<TSource, TResult>(IEnumerable<TSource> enumerable, Func<TSource, TResult> selector)
		{
			return ToArray(Select(enumerable, selector));
		}

		public static TResult[] SelectToArray<TSource, TResult>(IEnumerable enumerable, Func<TSource, TResult> selector)
		{
			List<TResult> list = new List<TResult>();
			foreach (TSource item in enumerable)
			{
				list.Add(selector(item));
			}
			return list.ToArray();
		}

		public static IntPtr[] SelectPtrs(IEnumerable<Mat> enumerable)
		{
			return SelectToArray(enumerable, delegate(Mat obj)
			{
				if (obj == null)
				{
					throw new ArgumentException("enumerable contains null");
				}
				obj.ThrowIfDisposed();
				return obj.CvPtr;
			});
		}

		public static IntPtr[] SelectPtrs(IEnumerable<InputArray> enumerable)
		{
			return SelectToArray(enumerable, delegate(InputArray obj)
			{
				if (obj == null)
				{
					throw new ArgumentException("enumerable contains null");
				}
				obj.ThrowIfDisposed();
				return obj.CvPtr;
			});
		}

		public static IEnumerable<TSource> Where<TSource>(IEnumerable<TSource> enumerable, Func<TSource, bool> predicate)
		{
			if (enumerable == null)
			{
				throw new ArgumentNullException("enumerable");
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			foreach (TSource item in enumerable)
			{
				if (predicate(item))
				{
					yield return item;
				}
			}
		}

		public static TSource[] WhereToArray<TSource>(IEnumerable<TSource> enumerable, Func<TSource, bool> predicate)
		{
			return ToArray(Where(enumerable, predicate));
		}

		public static TSource[] ToArray<TSource>(IEnumerable<TSource> enumerable)
		{
			if (enumerable == null)
			{
				return null;
			}
			TSource[] array = enumerable as TSource[];
			if (array != null)
			{
				return array;
			}
			return new List<TSource>(enumerable).ToArray();
		}

		public static bool Any<TSource>(IEnumerable<TSource> enumerable, Func<TSource, bool> predicate)
		{
			if (enumerable == null)
			{
				throw new ArgumentNullException("enumerable");
			}
			foreach (TSource item in enumerable)
			{
				if (predicate(item))
				{
					return true;
				}
			}
			return false;
		}

		public static bool AnyNull<TSource>(IEnumerable<TSource> enumerable) where TSource : class
		{
			if (enumerable == null)
			{
				throw new ArgumentNullException("enumerable");
			}
			if (typeof(TSource).IsValueType)
			{
				return false;
			}
			foreach (TSource item in enumerable)
			{
				if (item == null)
				{
					return true;
				}
			}
			return false;
		}

		public static bool All<TSource>(IEnumerable<TSource> enumerable, Func<TSource, bool> predicate)
		{
			if (enumerable == null)
			{
				throw new ArgumentNullException("enumerable");
			}
			foreach (TSource item in enumerable)
			{
				if (!predicate(item))
				{
					return false;
				}
			}
			return true;
		}

		public static int Count<TSource>(IEnumerable<TSource> enumerable, Func<TSource, bool> predicate)
		{
			if (enumerable == null)
			{
				throw new ArgumentNullException("enumerable");
			}
			int num = 0;
			foreach (TSource item in enumerable)
			{
				if (predicate(item))
				{
					num++;
				}
			}
			return num;
		}

		public static int Count<TSource>(IEnumerable<TSource> enumerable)
		{
			if (enumerable == null)
			{
				throw new ArgumentNullException("enumerable");
			}
			TSource[] array = enumerable as TSource[];
			if (array != null)
			{
				return array.Length;
			}
			ICollection<TSource> collection = enumerable as ICollection<TSource>;
			if (collection != null)
			{
				return collection.Count;
			}
			int num = 0;
			foreach (TSource item in enumerable)
			{
				TSource val = item;
				num++;
			}
			return num;
		}

		public static bool IsEmpty<TSource>(IEnumerable<TSource> enumerable)
		{
			if (enumerable == null)
			{
				throw new ArgumentNullException("enumerable");
			}
			using (IEnumerator<TSource> enumerator = enumerable.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					TSource current = enumerator.Current;
					return false;
				}
			}
			return true;
		}
	}
}
