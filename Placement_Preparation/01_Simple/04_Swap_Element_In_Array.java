public class Swap_Element_In_Array {
    public static void main(String[] args) {
        int[] arr={5,6,8,9,4,5,8,9};
        int temp;
        for(int i=0;i<arr.length;i=i+2){
            temp=arr[i];
            arr[i]=arr[i+1];
            arr[i+1]=temp;
            System.out.print(arr[i]+" "+arr[i+1]+" ");
        }
    }
}
