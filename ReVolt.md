# Re-Volt
You will be given an integer __n__ for the size of the square matrix and an integer for the count of commands. On the next __n__ lines, you will receive the rows of the matrix. The player starts at a random position (the player is marked with "__f__") and all of the __empty slots__ will be filled with "__-__" (__dash__). The goal is to reach the finish mark which will be marked with "__F__". On the field there can also be bonuses and traps. Bonuses are marked with "__B__" and traps are marked with "__T__".

Each turn you will be given commands for __the player’s movement__. If the player __goes out__ of the matrix, he comes in from __the other side__. For example, if the player is on 0, 0 and the next command is left, he goes to the last spot on the first row.

If the player steps on a bonus, he should move another step forward in the direction he is going. If the player steps on a trap, he should move a step backwards.

When the player reaches the __finish mark__ or the __count of commands__ is reached the game ends.

## Input
- On the first line, you are given the integer N – the size of the square matrix.
- On the second you are given the count of commands.
- The next N lines holds the values for every row.
- On each of the next lines you will get commands for movement directions.
## Output
- If the player reaches the finish mark, print: 
  - "__Player won!__"
- If the player reaches the commands count and hasn’t reached the finish mark print:
  - "__Player lost!__"
- In the end print the matrix.
## Constraints
- The size of the matrix will be between __[2…20]__.
- The players will always be indicated with "__f__".
- If the player steps on the finish mark at the same time as his last command, he wins the game.
- Commands will be in the format __up__, __down__, __left__ or __right__.
- There won't be a case where you bypass the finish while you are on a trap or a bonus.
- A trap will never place you into a bonus or another trap and a bonus will never place you into a trap or another bonus.
## Examples
|Input&nbsp; &nbsp; &nbsp;|Output&nbsp; &nbsp; &nbsp;|Comments&nbsp; &nbsp; &nbsp;|
|-------------------------|--------------------------|----------------------------|
5<br>5<br>-----<br>-f---<br>-B---<br>--T--<br>-F---<br>down<br>right<br>down|Player won!<br>-----<br>-----<br>-B---<br>--T--<br>-f---|The first command is down so f moves down. On turn 1, the player steps<br> on a bonus and does an additional step. On turn 2, the player<br> steps on a trap and goes a step back. After each turn the field is:<table><thead><tr><th>1</th><th>2</th><th>3</th></tr></thead><tbody><tr><td>-----</td><td>-----</td><td>-----</td></tr><tr><td>-----</td><td>-----</td><td>-----</td></tr><tr><td>-B---</td><td>-B---</td><td>-B---</td></tr><tr><td>-fT--</td><td>-fT--</td><td>--T--</td></tr></tr><tr><td>-F---</td><td>-F---</td><td>-f---</td></tr></tbody></table>On turn 3 f reaches the finish 'F' and wins the game.
4<br>3<br>----<br>-f-B<br>--T-<br>---F<br>up<br>up<br>left|Player lost!<br>----<br>---B<br>--T-<br>f--F
