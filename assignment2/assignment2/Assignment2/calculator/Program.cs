using System;

namespace Homework2 {

    class Calculator {

        public static void Main(string[] args) {
            double[] nums = { 2.1, 3, 0, 5.2, 10, 90, 102, 4.6, 2, 0 };

            try {
                Calculate(nums, out double min, out double max, 
                    out double sum, out double average);
                Console.WriteLine(
                    $"min={min},max={max},sum={sum},average={average}");
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        //计算数组元素的最小值、最大值、和与平均值
        private static void Calculate(double[] nums, 
            out double min, out double max, out double sum, out double average) {

            if (nums == null || nums.Length == 0) {
                throw new ArgumentException("数组不能为null或者空数组");
            }

            max = nums[0];
            min = nums[0];
            sum = 0;
            foreach (double n in nums) {
                if (n > max) max = n;
                if (n < min) min = n;
                sum += n;
            }
            average = sum / nums.Length;

        }

    }
}
