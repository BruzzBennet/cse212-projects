using System.Xml.Serialization;

public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        int[] v_list1 = list1;
        int[] v_list2 = list2;
        int[] v_listS = select;
        var results = new int[select.Count()];
        int l1 = 0;
        int l2 = 0;
        for (int i = 0; i < v_listS.Count(i => i != 0); i++)
        {
            if (v_listS.ElementAt(i) == 1)
            {
                results[i] = v_list1.ElementAt(l1);
                l1++;
            }
            else if (v_listS.ElementAt(i) == 2)
            {
                results[i] = v_list2.ElementAt(l2);
                l2++;
            }
        }

        return results;
    }
}