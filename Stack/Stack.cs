namespace Stack
{
    public class Stack
    {
        private double[] arr;
        private int index;

        public Stack()
        {
            arr = new double[225];
            index = 0;
        }

        public bool Push(double value)
        {
            if (index >= 225) throw new Exception("Stack overflow");
            arr[index] = value;
            index = index + 1;
            return true;
        }

        public double Pop()
        {
            if (index <= 0) throw new Exception("Stack empty");
            index = index - 1;
            double result = arr[index];
            arr[index] = 0;
            return result;
        }

        public void Dump()
        {
            for (int i = 0; i < index; i++)
            {
                Console.Write(arr[i]);
            }
        }

        public void Clear()
        {
            arr = new double[225];
        }
    }
}