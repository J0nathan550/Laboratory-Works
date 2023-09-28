// Написати програму, яка в циклі введе 8 чисел і порахує кількість тих чисел, які менші за 1 і більше 0
while (true) {
    let count = 0;
    let i = 1; 
    while (i <= 8) {
        let number = parseFloat(prompt("Введіть число від " + i + ": "));
        if (!isNaN(number) && number > 0 && number < 1) {
            count++;
        }
        i++;
    }
    alert("Сумма чисел, які були менше за 1 та більше за 0: " + count);
}