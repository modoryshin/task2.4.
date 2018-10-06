using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace task2._4
{
    class Program
    {
        static int[] Numbers(string txt)
        {
            txt = txt.Trim(' ');
            Regex r = new Regex(@"[\s]");
            string[] nums = r.Split(txt);
            int[] num = new int[nums.Length];
            for(int i = 0; i < nums.Length; i++)
            {
                num[i] = Convert.ToInt32(nums[i].Trim(' '));
            }
            return num;
        }
        static bool AsNeed(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[i - 1]) return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            FileStream f = new FileStream("input.txt", FileMode.OpenOrCreate);
            StreamReader r = new StreamReader(f);
            string txt = r.ReadLine();
            int[] num = Numbers(txt);
            txt = r.ReadLine();
            int[] array = Numbers(txt);
            r.Close();
            f.Close();
            int k = num[1];
            bool needConttinue = false;
            int tmp = -1;
            do
            {
                needConttinue = false;
                for (int i = 0; i < array.Length - k; i++)
                {
                    if (array[i] > array[i + k])
                    {
                        tmp = array[i];
                        array[i] = array[i + k];
                        array[i + k] = tmp;
                        needConttinue = true;
                    }
                }
            } while (needConttinue);
            FileStream f1 = new FileStream("output.txt", FileMode.OpenOrCreate);
            StreamWriter w = new StreamWriter(f1);
            bool end = AsNeed(array);
            if (end == true)
                w.WriteLine("YES");
            else
                w.WriteLine("NO");
            w.Close();
            f.Close();
        }
    }
}
