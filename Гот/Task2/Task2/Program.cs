using System;

namespace Task2
{
    class Program
    {
        public static float[] Hf;
        public static float[] TempHf;
        public static float[] Hf2;
        public static float[] TempHf2;
        static void Main(string[] args)
        {
            Console.WriteLine("14.	Используя массивы, реализовать основные операции над множествами:\n" +
    "-определение принадлежности элемента a множеству S;\n" +
    "-добавление элемента а в S\n" 
    +"-удаление элемента а из S\n"+
    "-объединение элементов двух множеств.");
            bool ready = true;
            while (ready)
            {
                try
                {
                    if (Hf != null)
                    Console.WriteLine("[{0}]", string.Join(", ", Hf));
                    Console.WriteLine();
                    Console.WriteLine("1.Вести множества\n" +
                                      "2.Определение принадлежности элемента a множеству S\n" +
                                      "3.Добавление элемента а в S\n" +
                                      "4.Удаление элемента а из S\n" +
                                      "5.Объединение элементов двух множеств\n" +
                                      "6.Выход\n");
                    int a = Convert.ToInt32(Console.ReadLine());


                    switch (a)
                    {
                        case 1:
                            {
                                if (Hf == null)
                                {
                                    Hf = (float[])Split(Console.ReadLine()).Clone();
                                }
                                else
                                {
                                    Array.Clear(Hf, 0, Hf.Length);
                                    Array.Resize(ref Hf, 0);
                                    TempHf = (float[])Split(Console.ReadLine()).Clone();
                                    Array.Resize(ref Hf, TempHf.Length);
                                    Hf = (float[])TempHf.Clone();

                                }

                                break;
                            }
                        case 2:
                            {
                                if (Hf != null)
                                {
                                    Console.WriteLine("Ведите элемент:");
                                    Console.WriteLine(isInArray(Hf, Convert.ToSingle(Console.ReadLine())));
                                }
                                else
                                {
                                    Console.WriteLine("Массив пустой.");
                                }
                                break;
                            }
                        case 3:
                            {
                                if (Hf != null)
                                {
                                    Console.WriteLine("Индекс\n" +
                                                      "Потом элемент");
                                    Hf = addElement(Hf, Convert.ToInt32(Console.ReadLine()), Convert.ToSingle(Console.ReadLine()));
                                }
                                else
                                {
                                    Console.WriteLine("Массив пустой.");
                                }
                                break;
                            }
                        case 4:
                            {
                                if (Hf != null)
                                {
                                    Console.WriteLine("Индекс");
                                    Hf = removeElement(Hf, Convert.ToInt32(Console.ReadLine()));
                                }
                                else
                                {
                                    Console.WriteLine("Массив пустой.");
                                }
                                break;
                            }
                        case 5:
                            {
                                if (Hf2 == null)
                                {
                                    Console.WriteLine("Ведите 2 массив");
                                    Hf2 = (float[])Split(Console.ReadLine()).Clone();
                                    Hf = mergeArrays(Hf, Hf2);
                                }
                                else
                                {
                                    Array.Clear(Hf2, 0, Hf2.Length);
                                    Array.Resize(ref Hf2, 0);
                                    Console.WriteLine("Ведите 2 массив");
                                    TempHf2 = (float[])Split(Console.ReadLine()).Clone();
                                    Array.Resize(ref Hf2, TempHf2.Length);
                                    Hf2 = (float[])TempHf2.Clone();
                                    Hf = mergeArrays(Hf, Hf2);
                                }
                                break;
                            }
                        case 6:
                            {
                                ready = false;
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static float[] Split(string number)
        {
            string[] words = number.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            float[] Sf = new float[words.Length];
            int i = 0;
            foreach (string s in words)
            {
                Sf[i] = Convert.ToSingle(s);
                i++;
            }

            return Sf;
        }
        public static bool isInArray(float[] array, float element)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    return true;
                }
            }
            return false;
        }
        public static float[] addElement(float[] array, int index, float element)
        {
            float[] result = new float[array.Length + 1];
            for (int i = 0; i < index; i++)
            {
                result[i] = array[i];
            }
            result[index] = element;
            for (int i = index + 1; i < result.Length; i++)
            {
                result[i] = array[i - 1];
            }
            return result;
        }
        public static float[] removeElement(float[] array, int index)
        {
            float[] result = new float[array.Length - 1];
            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (index != i)
                {
                    result[k] = array[i];
                    k++;
                }
            }
            return result;
        }

        public static float[] mergeArrays(float[] array1, float[] array2)
        {
            float[] result = new float[array1.Length + array2.Length];
            for (int i = 0; i < array1.Length; i++)
            {
                result[i] = array1[i];
            }


            for (int j = 0; j < array2.Length; j++)
            {
                result[array1.Length + j] = array2[j];

            }
            return result;
        }

    }
}
