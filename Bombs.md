# Bombs

*Ezio is still learning to make bombs. With their help, he will save civilization. We should help Ezio to make his perfect bombs.*

You will be given __two sequences__ of __integers__, representing __bomb effects__ and __bomb casings__.

You need to start from the __first bomb effect__ and try to mix it with the __last bomb casing__. If the __sum__ of their values is __equal to any of the materials__ in the table below – create the bomb corresponding to the value and __remove__ the __both bomb materials__. Otherwise, just __decrease__ the value of the __bomb casing__ by __5__. You need to __stop__ combining when you have __no more bomb effects__ or __bomb casings__, or you successfully __filled the bomb pouch__.

Bombs:
- Datura Bombs: 40
- Cherry Bombs: 60
- Smoke Decoy Bombs: 120

To fill the bomb pouch, Ezio needs __three of each__ of the __bomb types__.

## Input
- On the __first line__, you will receive the integers representing the __bomb effects, separated by ", "__.
- On the __second line__, you will receive the integers representing the __bomb casing, separated by ", "__.

## Output
- On the __first line__ of output – print one of these rows according whether Ezio succeeded fulfill the bomb pouch:
  - "__Bene! You have successfully filled the bomb pouch!__"
  - "__You don't have enough materials to fill the bomb pouch.__"
- On the __second line__ - print all bomb effects left:
  - If there are no bomb effects: "__Bomb Effects: empty__"
  - If there are effects: "__Bomb Effects: {bombEffect1}, {bombEffect2}, (…)__"
- On the __third line__ - print all bomb casings left:
  - If there are no bomb casings: "__Bomb Casings: empty__"
  - If there are casings: "__Bomb Casings: {bombCasing1}, {bombCasing2}, (…)__"
- Then, you need to print all created bombs and the count you have of them, ordered __alphabetically__:
  - "__Cherry Bombs: {count}__"
  - "__Datura Bombs: {count}__"
  - "__Smoke Decoy Bombs: {count}__"

## Constraints
- All of the given numbers will be valid integers in the range __[0, 120]__.
- Don't have situation with negative material.

## Examples
<table style="width: 100%;">
  <tr>
    <th>
      Input
    </th>
    <th>
      Output
    </th>
    <th>
      Comment
    </th>
  </tr>
  <tbody>
    <tr>
      <td style="width=35%;"><sub>5, 25, 50, 115<br>5, 15, 25, 35</sub></td>
      <td style="width=30%;"><sub>You don't have enough materials to fill the bomb pouch.<br>Bomb Effects: empty<br>Bomb Casings: empty<br>Cherry Bombs: 1<br>Datura Bombs: 2<br>Smoke Decoy Bombs: 1</sub></td>
      <td style="width=35%;"><sub>1) 5 + 35 = 40 -> Datura Bomb. Remove both.<br>2) 25 + 25 = 50 -> can't create bomb.<br>Bomb casing should be decreased with 5 -> 20<br>3) 25 + 20 = 45 -> can't create bomb.<br>Bomb casing should be decreased with 5 -> 15<br>4) 25 + 15 = 40 -> Datura Bomb. Remove both</sub></td>
    </tr>
    <tr>
      <td style="width=35%;"><sub>30, 40, 5, 55, 50, 100, 110, 35, 40, 35, 100, 80<br>20, 25, 20, 5, 20, 20, 70, 5, 35, 0, 10</sub></td>
      <td style="width=30%;"><sub>Bene! You have successfully filled the bomb pouch!<br>Bomb Effects: 100, 80<br>Bomb Casings: 20<br>Cherry Bombs: 3<br>Datura Bombs: 4<br>Smoke Decoy Bombs: 3</sub></td>
      <td style="width=35%;"><sub>After creating a bomb with bomb effect 35 and bomb casing 25,<br>have created 3 Cherry bombs, 4 Datura bombs, and<br>3 Smoke Decoy bombs. From all of the bomb types<br>have 3 bombs and the program ends.</sub></td>
    </tr>
  </tbody>
</table>

