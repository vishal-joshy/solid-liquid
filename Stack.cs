public class Stack{
    private int[] arr;
    private int index;

    public Stack(){
        arr = new int[225];
        index = 0;
    }

    public bool Push(int value){
        if(index>=225) throw new Exception("Stack overflow");
        arr[index] = value;
        index=index+1;
        return true;
    }

    public int Pop(){
        if(index<=0) throw new Exception("Stack empty");
        int result = arr[index];
        index=index-1;
        return result;
    }

    public void Dump(){
        for (int i = 0; i < index;i++){
            Console.Write(arr[i]);
        }
    }

}