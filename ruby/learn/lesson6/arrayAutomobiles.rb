automobiles = [
    "Toyota",
    "Ford",
    "Subaru",
    "Volvo",
    "Mitsubishi",
    "Honda",
    "Saab",
    "Tesla",
    "Kia",
    "Audi",
]

puts "Размер массива: #{automobiles.count}"

firstIndex = automobiles.index(automobiles.first)
lastIndex = automobiles.index(automobiles.last)

puts "Пожалуйта, введите число от #{firstIndex} до #{lastIndex}: "
selectNumber = gets.to_i

if !(selectNumber < firstIndex || selectNumber > lastIndex || selectNumber < 0)
    puts "Поздравляю, Вы получили: #{automobiles[selectNumber]}"
else
    puts "Некорректный номер."
end