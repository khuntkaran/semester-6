public class Array_Element_Not_Present_In_Second_Array {
    public static void main(String[] args) {
        int[] arr1={1,2,3,4,5};
        int[] arr2={2,3,1,0,5};
        boolean flag=false;
        for(int i:arr1){
            flag=false;
            for(int j:arr2){
                if(j==i){
                    flag=true;
                    break;
                }
            }
            if(!flag){
                System.out.println(i+" ");
            }
        }
    }
}
