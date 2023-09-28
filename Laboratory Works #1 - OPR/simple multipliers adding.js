// Дано натуральне число п. Вивести розкладання цього числа на прості множники.Кожен простий множник має бути надрукований стільки разів, скільки разів він входить до розкладання.
while (true) {
    let n = parseInt(prompt("Введіть натуральне число:"));
    let column_solving = "";
    let n_original = n;
    let divisor = 2;
    if (!isNaN(n)) {
        if (n < 1) {
            alert("Число: " + n_original + " ні є натуральним числом!");
        }
        else {
            while (n != 1 && n != 0) {
                if (n % divisor != 0) {
                    divisor++;
                }
                else {
                    column_solving += n + "     |     ";
                    n /= divisor;
                    column_solving += divisor + "\n";
                }
            }
            column_solving += n + "     |     ";
            alert("Рішення числа: " + n_original + ":\n" + column_solving);
        }
    }
    else { 
        alert("Введіть нормальне число а не текст, або нічого!");
    }
}