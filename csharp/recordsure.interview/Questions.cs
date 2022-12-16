using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace recordsure.interview {
	public class Questions {	
		
		/// <summary>
		/// Given an enumerable of strings, attempt to parse each string and if
		/// it is an integer, add it to the returned enumerable.
		///
		/// For example:
		///
		/// ExtractNumbers(new List<string> { "123", "hello", "234" });
		///
		/// ; would return:
		///
		/// {
		///   123,
		///   234
		/// }
		/// </summary>
		/// <param name="source">An enumerable containing words</param>
		/// <returns></returns>
		public IEnumerable<int> ExtractNumbers(IEnumerable<string> source) {
	List<int> parsedIntegers = source.Select(str => {
		int result;
		
		if (int.TryParse(str, out result)) {
			return (int?) result;
		} else {
			return null;
		}
	}).Where(i => i != null).Select(i => (int)i).ToList();

	return parsedIntegers;
}


		/// <summary>
		/// Given two enumerables of strings, find the longest common word.
		///
		/// For example:
		///
		/// LongestCommonWord(
		///     new List<string> {
		///         "love",
		///         "wandering",
		///         "goofy",
		///         "sweet",
		///         "mean",
		///         "show",
		///         "fade",
		///         "scissors",
		///         "shoes",
		///         "gainful",
		///         "wind",
		///         "warn"
		///     },
		///     new List<string> {
		///         "wacky",
		///         "fabulous",
		///         "arm",
		///         "rabbit",
		///         "force",
		///         "wandering",
		///         "scissors",
		///         "fair",
		///         "homely",
		///         "wiggly",
		///         "thankful",
		///         "ear"
		///     }
		/// );
		///
		/// ; would return "wandering" as the longest common word.
		/// </summary>
		/// <param name="first">First list of words</param>
		/// <param name="second">Second list of words</param>
		/// <returns></returns>
	public string LongestCommonWord(IEnumerable<string> first, IEnumerable<string> second) {
	string longestCommonWord = first.Intersect(second)
		.OrderByDescending(str => str.Length)
		.FirstOrDefault();

	return longestCommonWord;
}

		
		
		/// <summary>
		/// Write a method that converts kilometers to miles, given that there are
		/// 1.6 kilometers per mile.
		///
		/// For example:
		///
		/// DistanceInMiles(16.00);
		///
		/// ; would return 10.00;
		/// </summary>
		/// <param name="km">distance in kilometers</param>
		/// <returns></returns>
		public double ConvertKilometersToMiles(double kilometers) {
	const double KILOMETERS_PER_MILE = 1.6;
	return kilometers / KILOMETERS_PER_MILE;
}

public double DistanceInMiles(double km) {
	return ConvertKilometersToMiles(km);
}

		

		/// <summary>
		/// Write a method that converts miles to kilometers, give that there are
		/// 1.6 kilometers per mile.
		///
		/// For example:
		///
		/// DistanceInKm(10.00);
		///
		/// ; would return 16.00;
		/// </summary>
		/// <param name="miles">distance in miles</param>
		/// <returns></returns>
		public double ConvertMilesToKilometers(double miles) {
	const double KILOMETERS_PER_MILE = 1.6;
	return miles * KILOMETERS_PER_MILE;
}

public double DistanceInKm(double miles) {
	return ConvertMilesToKilometers(miles);
}

		
		/// <summary>
		/// Write a method that returns true if the word is a palindrome, false if
		/// it is not.
		///
		/// For example:
		///
		/// IsPalindrome("bolton");
		///
		/// ; would return false, and:
		///
		/// IsPalindrome("Anna");
		///
		/// ; would return true.
		///
		/// Also complete the related test case for this method.
		/// </summary>
		/// <param name="word">The word to check</param>
		/// <returns></returns>
		
		public bool IsPalindrome(string word)
{
	string normalizedWord = new string(word.ToLower().Where(char.IsLetter).ToArray());

	for (int i = 0; i < normalizedWord.Length / 2; i++)
	{
		if (normalizedWord[i] != normalizedWord[normalizedWord.Length - i - 1])
		{
			return false;
		}
	}
	return true;
}

public bool OutputPalindrome()
{
	bool isPalindrome = IsPalindrome("samuelname");
	return isPalindrome;
}

					
		/// <summary>
		/// Write a method that takes an enumerable list of objects and shuffles
		/// them into a different order.
		///
		/// For example:
		///
		/// Shuffle(new List<string>{ "one", "two" });
		///
		/// ; would return:
		///
		/// {
		///   "two",
		///   "one"
		/// }
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		
		public IEnumerable<object> Shuffle(IEnumerable<object> source)
{
	IList<object> list = new List<object>(source);

	Random rng = new Random();

	int n = list.Count;
	while (n > 1)
	{
		n--;
		int k = rng.Next(n + 1);
		object value = list[k];
		list[k] = list[n];
		list[n] = value;
	}
	return list;
}

public IEnumerable<object> ShuffledObj()
{
	IEnumerable<object> shuffledNumbers = Shuffle(new List<string>{ "one", "two" });
	return shuffledNumbers;
}

		/// <summary>
		/// Write a method that sorts an array of integers into ascending
		/// order - do not use any built in sorting mechanisms or frameworks.
		///
		/// Complete the test for this method.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>

		public int[] Sort(int[] source)
{
	// Loop through the array, comparing each element to the next element
	for (int i = 0; i < source.Length - 1; i++)
	{
		for (int j = i + 1; j < source.Length; j++)
		{
			// If the current element is greater than the next element, swap them
			if (source[i] > source[j])
			{
				int temp = source[i];
				source[i] = source[j];
				source[j] = temp;
			}
		}
	}
	return source;
}
		
public int[] DisplaySortedInput()
{
	int[] sortedArray = Sort(new int[] { 4, 2, 7, 1, 3 });
			return sortedArray;
		}


		/// <summary>
		/// Each new term in the Fibonacci sequence is generated by adding the
		/// previous two terms. By starting with 1 and 2, the first 10 terms will be:
		///
		/// 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
		///
		/// By considering the terms in the Fibonacci sequence whose values do
		/// not exceed four million, find the sum of the even-valued terms.
		/// </summary>
		/// <returns></returns>

		public int FibonacciSum() 
{
	int a = 1, b = 2, c = 0, sum = 0;

	while (c <= 4000000)
	{
		c = a + b;
		a = b;
		b = c;

		if (c % 2 == 0)
		{
			sum += c;
		}
	}

	return sum;
}

public int DisplayFibonacciSum()
{
	int result = FibonacciSum();
			return result;
		}

		/// <summary>
		/// Generate a list of integers from 1 to 100.
		///
		/// This method is currently broken, fix it so that the tests pass.
		/// </summary>
		/// <returns></returns>
		
		public IEnumerable<int> GenerateList()
{
	var ret = new List<int>();
	var numThreads = 4;

	Thread[] threads = new Thread[numThreads];
	for (var i = 0; i < numThreads; i++)
	{
		threads[i] = new Thread(() =>
		{
			var complete = false;
			while (!complete)
			{
				var next = ret.Count + 1;
				if (next <= 100)
				{
					ret.Add(next);
				}

				if (ret.Count >= 100)
				{
							complete = true;
						}
					}
				});
				threads[i].Start();
			}

			for (var i = 0; i < numThreads; i++) {
				threads[i].Join();
			}

			return ret;
		}
	}
}
