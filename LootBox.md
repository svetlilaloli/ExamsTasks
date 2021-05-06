# Loot box

*You are tired of being the only one on your team without cool items, so you decided buy some loot boxes which have a chance to drop some cool items.*

Every purchase gives you two loot boxes and they are represented as a sequence of integers. First, you will be given __a sequence of integers, representing the first loot box__. Afterwards, you will be given another __sequence of integers representing the second loot box__. 

You need to start from the __first item__ in the __first box__ and __sum__ it with the __last item__ in the __second box__. If the __sum__ of their values is an __even__ number, __add__ the summed item to your __collection of claimed items__ and __remove them both from the boxes__. Otherwise, __move the last item from the second box__ and __add__ it at the __last position in the first box__. You need to __stop__ summing items when one of the boxes becomes empty.

If the first loot box becomes empty print:

__"First lootbox is empty"__

If the second loot box becomes empty print:

__"Second lootbox is empty"__

In the end you need to determine the quality of your claimed items. If the sum of the claimed items equal to or greater than 100, print:

__"Your loot was epic! Value: {sum of claimed items}"__

Else print:

__"Your loot was poor... Value: {sum of claimed items}"__
## Input
- On the __first line__, you will receive the integers representing the __first loot box__, __separated__ by a __single space__. 
- On the __second line__, you will receive the integers representing the __second loot box__, __separated__ by a __single space__.
## Output
- On the __first__ line of output – print which box got empty in the format described above.
- On the __second__ line – the quality of your loot in the format described above.
## Constraints
- All of the given numbers will be valid integers in the range __[0, 100]__.
- There won’t be a case where both loot boxes become empty at the same time.
## Examples
Input|Output|Comment
-----|------|-------
10 11 8 13 5 6<br>0 4 7 3 6 23 3|Second lootbox is empty<br>Your loot was poor... Value: 42|First we sum 10 and 3. We get 13, which<br> is not an even number, so we<br> take the last item from the second box<br> and move it to last position in the first box.<br>The current state of the boxes:<br>10 11 8 13 5 6 3<br>0 4 7 3 6 23<br>The next sum is 33 so we do the same again. On the third<br>iteration the sum is 16 which is an even number,<br>so we remove both of the boxes and<br>we add the value to our claimed items.<br>We keep summing items until one of the<br>boxes becomes empty.
20 40 60 80 100<br>10 20 30 40 50 60|First lootbox is empty<br>Your loot was epic! Value: 500	
