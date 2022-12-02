/**
 * A class to represents a single item of a SinglyLinkedList that can be
 * linked to other Node instances to form a list of linked nodes.
 */
class ListNode {
    /**
     * Constructs a new Node instance. Executed when the 'new' keyword is used.
     * @param {any} data The data to be added into this new instance of a Node.
     *    The data can be anything, just like an array can contain strings,
     *    numbers, objects, etc.
     * @returns {ListNode} A new Node instance is returned automatically without
     *    having to be explicitly written (implicit return).
    */
    constructor(data) {
        this.data = data;
        /**
         * This property is used to link this node to whichever node is next
         * in the list. By default, this new node is not linked to any other
         * nodes, so the setting / updating of this property will happen sometime
         * after this node is created.
         *
         * @type {ListNode|null}
         */
        this.next = null;
    }
}

/**
 * This class keeps track of the start (head) of the list and to store all the
 * functionality (methods) that each list should have.
 */
class SinglyLinkedList {
    /**
     * Constructs a new instance of an empty linked list that inherits all the
     * methods.
     * @returns {SinglyLinkedList} The new list that is instantiated is implicitly
     *    returned without having to explicitly write "return".
    */
    constructor() {
        /** @type {ListNode|null} */
        this.head = null;
    }
    /**
  * Concatenates the nodes of a given list onto the back of this list.
  * - Time: O(?).
  * - Space: O(?).
  * @param {SinglyLinkedList} addList An instance of a different list whose
  *    whose nodes will be added to the back of this list.
  * @returns {SinglyLinkedList} This list with the added nodes.
  */
    concat(addList) {
        if (this.isEmpty()) {
            return addList
        }
        let runner = this.head
        while (runner.next) {
            runner = runner.next
        }
        runner.next = addList.head
        return this
    }

    splitOnVal(val) {
        if (this.isEmpty() || val === this.head.data) {
            return this
        }
        let newList = new SinglyLinkedList()
        if(val === this.head.data){
            newList.head = this.head
            this.head = null
            return newList
        }
        let runner = this.head
       
        while (runner.next) {
            if (runner.next.data === val) {

                newList.head = runner.next
                runner.next = null
                return newList
            }
            runner = runner.next
        }
        return null
    }

    /**
     * Finds the node with the smallest data and moves that node to the front of
     * this list.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {SinglyLinkedList} This list.
     */
    moveMinToFront() {
        if (this.isEmpty()) {
            return this
        }
        let min = this.head.data
        let runner = this.head
        while (runner) {
            if (runner.data < min) {
                min = runner.data
            }
            runner = runner.next
        }

        this.removeVal(min)
        return this.insertAtFront(min)

    }

    // EXTRA
    /**
     * Splits this list into two lists where the 2nd list starts with the node
     * that has the given value.
     * splitOnVal(5) for the list (1=>3=>5=>2=>4) will change list to (1=>3)
     * and the return value will be a new list containing (5=>2=>4)
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} val The value in the node that the list should be split on.
     * @returns {SinglyLinkedList} The split list containing the nodes that are
     *    no longer in this list.
     */


    /**
   * Retrieves the data of the second to last node in this list.
   * - Time: O(?).
   * - Space: O(?).
   * @returns {any} The data of the second to last node or null if there is no
   *    second to last node.
  */
    secondToLast() {
        //if list is empty or only 1
        if (this.isEmpty() || this.head.next === null) {
            return null;
        }
        //loop through the list until the 2rd to last
        let runner = this.head;
        while (runner.next.next) {
            runner = runner.next
        }
        //return data
        const returnData = runner.data;
        return returnData;
    }

    /**
     * Removes the node that has the matching given val as it's data.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} val The value to compare to the node's data to find the
     *    node to be removed.
     * @returns {boolean} Indicates if a node was removed or not.
     * 
     * //edge: if head is val, if last is val
    */
    removeVal(val) {
        //if list is empty
        if (this.isEmpty()) {
            return false;
        }
        //if head is the val
        if (this.head.data === val) {
            this.removeHead();
            return true;
        }
        //loop through whole list
        let runner = this.head;
        while (runner.next) {
            if (runner.next.data === val) {
                //if it's the last node
                if (runner.next.next === null) {
                    runner.next = null;
                    return true;
                }
                runner.next = runner.next.next;
                return true;
            }
            runner = runner.next;
        }
        return false;
    }


    // EXTRA
    /**
     * Inserts a new node before a node that has the given value as its data.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} newVal The value to use for the new node that is being added.
     * @param {any} targetVal The value to use to find the node that the newVal
     *    should be inserted in front of.
     * @returns {boolean} To indicate whether the node was pre-pended or not.
    */
    prepend(newVal, targetVal) {
        //if list is empty
        if (this.isEmpty()) {
            return false;
        }
        //if head is the targetVal
        if (this.head.data === targetVal) {
            this.insertAtFront(newVal);
            return true;
        }
        const newNode = new ListNode(newVal);
        let runner = this.head;
        while (runner.next) {
            if (runner.next.data === targetVal) {
                newNode.next = runner.next;
                runner.next = newNode;
                return true;
            }
            runner = runner.next;
        }
        return false;
    }


    /**
    * Removes the last node of this list.
    * - Time: O(?).
    * - Space: O(?).
    * @returns {any} The data from the node that was removed.
   */
    removeBack() {
        if (this.head.next === null) {
            return this.removeHead()
        }
        let runner = this.head;
        let deleted = null
        while (runner.next !== null) {
            if (runner.next.next === null) {
                deleted = runner.next
                runner.next = null
            } else {
                runner = runner.next
            }
        }
        return deleted
    }

    /**
     * Determines whether or not the given search value exists in this list.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} val The data to search for in the nodes of this list.
     * @returns {boolean}
    */
    contains(val) {
        let runner = this.head;

        while (runner !== null) {
            if (runner.data === val) {
                return true
            }
            runner = runner.next
        }
        return false

    }

    /**
     * Determines whether or not the given search value exists in this list.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} val The data to search for in the nodes of this list.
     * @param {?ListNode} current The current node during the traversal of this list
     *    or null when the end of the list has been reached.
     * @returns {boolean}
    */
    containsRecursive(val, current = this.head) {
        if (current === null) {
            return false
        } else if (current.data === val) {
            return true
        }
        return this.containsRecursive(val, current.next)
    }

    // EXTRA
    /**
     * Recursively finds the maximum integer data of the nodes in this list.
     * - Time: O(?).
     * - Space: O(?).
     * @param {ListNode} runner The start or current node during traversal, or null
     *    when the end of the list is reached.
     * @param {ListNode} maxNode Keeps track of the node that contains the current
     *    max integer as it's data.
     * @returns {?number} The max int or null if none.
    */
    recursiveMax(runner = this.head, maxNode = this.head) {
        if (this.head === null) {
            return null
        }
        if (runner.data > maxNode.data) {
            maxNode = runner
        }
        if (runner.next === null) {
            return maxNode.data
        }
        return this.recursiveMax(runner.next, maxNode)
    }

    /**
 * Creates a new node with the given data and inserts that node at the front
 * of this list.
 * - Time: (?).
 * - Space: (?).
 * @param {any} data The data for the new node.
 * @returns {SinglyLinkedList} This list.
*/
    insertAtFront(data) {
        if (this.isEmpty()) {
            this.head = new ListNode(data)
            return this
        }
        let newHead = new ListNode(data);
        newHead.next = this.head;
        this.head = newHead;
        return this
    }


    /**
     * Removes the first node of this list.
     * - Time: (?).
     * - Space: (?).
     * @returns {any} The data from the removed node.
    */
    removeHead() {
        if (this.isEmpty()) {
            return null
        }
        let prevHead = this.head;
        this.head = prevHead.next;
        return prevHead.data;
    }

    // EXTRA
    /**
     * Calculates the average of this list.
     * - Time: (?).
     * - Space: (?).
     * @returns {number|NaN} The average of the node's data.
    */
    average() {
        if (this.isEmpty()) {
            return NaN;
        }
        let runner = this.head;
        let sum = 0;
        let count = 0;
        while (runner) {
            sum += runner.data;
            runner = runner.next;
            count++;
        }
        return sum / count;
    }

    /**
     * Determines if this list is empty.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {boolean}
    */
    isEmpty() {
        return this.head === null
    }


    /**
     * Creates a new node with the given data and inserts it at the back of
     * this list.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} data The data to be added to the new node.
     * @returns {SinglyLinkedList} This list.
    */
    insertAtBack(data) {
        if (this.isEmpty()) {
            this.head = new ListNode(data)
            return this
        }
        let runner = this.head
        while (runner.next) {
            runner = runner.next
        }
        runner.next = new ListNode(data)
        return this
    }

    /**
     * Creates a new node with the given data and inserts it at the back of
     * this list.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} data The data to be added to the new node.
     * @param {?ListNode} runner The current node during the traversal of this list
     *    or null when the end of the list has been reached.
     * @returns {SinglyLinkedList} This list.
    */
    insertAtBackRecursive(data, runner = this.head) {
        if (this.isEmpty()) {
            this.head = new ListNode(data)
            return this
        }
        if (!runner.next) {
            runner.next = new ListNode(data)
            return this
        }

        return this.insertAtBackRecursive(data, runner.next)
    }

    /**
     * Calls insertAtBack on each item of the given array.
     * - Time: O(n * m) n = list length, m = arr.length.
     * - Space: O(1) constant.
     * @param {Array<any>} vals The data for each new node.
     * @returns {SinglyLinkedList} This list.
    */
    insertAtBackMany(vals) {
        for (const item of vals) {
            this.insertAtBack(item);
        }
        return this;
    }



    /**
     * Converts this list into an array containing the data of each node.
     * - Time: O(n) linear.
     * - Space: O(n).
     * @returns {Array<any>} An array of each node's data.
    */
    toArr() {
        const arr = [];
        let runner = this.head;

        while (runner) {
            arr.push(runner.data);
            runner = runner.next;
        }
        return arr;
    }
}




/******************************************************************* 
 Multiple test lists already constructed to test your methods on.
Below commented code depends on insertAtBack method to be completed,
after completing it, uncomment the code.
*/
const emptyList = new SinglyLinkedList();

const singleNodeList = new SinglyLinkedList().insertAtBackMany([1]);
const biNodeList = new SinglyLinkedList().insertAtBackMany([1, 2, 0]);
// console.log(biNodeList.average())
// console.log(biNodeList.insertAtFront(5))
// console.log(biNodeList.removeHead())

const firstThreeList = new SinglyLinkedList().insertAtBackMany([5, 7, 1, 3, 2]);

console.log(emptyList.moveMinToFront().toArr())
console.log(singleNodeList.moveMinToFront().toArr())
console.log(biNodeList.moveMinToFront().toArr())


// const secondThreeList = new SinglyLinkedList().insertAtBackMany([4, 5, 6]);
// const unorderedList = new SinglyLinkedList().insertAtBackMany([
//   -5, -10, 4, -3, 6, 1, -7, -2,
// ]);

/* node 4 connects to node 1, back to head */
// const perfectLoopList = new SinglyLinkedList().insertAtBackMany([1, 2, 3, 4]);
// perfectLoopList.head.next.next.next = perfectLoopList.head;

/* node 4 connects to node 2 */
// const loopList = new SinglyLinkedList().insertAtBackMany([1, 2, 3, 4]);
// loopList.head.next.next.next = loopList.head.next;

// const sortedDupeList = new SinglyLinkedList().insertAtBackMany([
//   1, 1, 1, 2, 3, 3, 4, 5, 5,
// ]);

// Print your list like so:
// console.log(firstThreeList.toArr());