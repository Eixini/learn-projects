puts "Введите число 1:"
number1 = gets.chomp

puts "Введите число 2:"
number2 = gets.chomp

puts "Введите число 3:"
number3 = gets.chomp

average = (number1.to_i + number2.to_i + number3.to_i) / 3

puts "Среднее арифметическое: #{average}"