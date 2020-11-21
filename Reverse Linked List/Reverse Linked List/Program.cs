namespace Reverse_Linked_List
{
    public class ListNode
    {
        public int value;
        public ListNode next;
        public ListNode(int x) { value = x; }
    }
    class Program
    {
        public static ListNode head = new ListNode(1);
        static void Main(string[] args)
        {
            int nodes = 2;
            while (nodes < 6)
            {
                AppendToTail(nodes);
                nodes++;
            }
            //ReverseList(head);
            ReverseList_Cracking(head);
            int[] test = new int[5] { 1, 2, 3, 4, 5 };
            int l = test.Length;
        }

        public static void AppendToTail(int value)
        {
            ListNode end = new ListNode(value);
            ListNode node = head;
            while (node.next != null)
            {
                node = node.next;
            }
            node.next = end;
        }
        private static ListNode pReverseHead;
        public static ListNode ReverseList(ListNode head)
        {
            if (head == null) return pReverseHead;
            if (pReverseHead == null)
            {
                pReverseHead = head;
                head = head.next;
                pReverseHead.next = null;
            }
            else
            {
                ListNode tmp = head.next;
                head.next = pReverseHead;
                pReverseHead = head;
                head = tmp;
            }
            return ReverseList(head);
        } 

        // This is the good one
        public static ListNode ReverseList_Cracking(ListNode node)
        {
            ListNode head = null;
            while (node != null)
            {
                ListNode n = new ListNode(node.value);
                n.next = head;
                head = n;
                node = node.next;
            }
            return head;
        }
        public static ListNode ReverseListV3(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode newHead = ReverseListV3(head.next);
            head.next.next = head;
            head.next = null;

            return newHead;
        }
    }
}
