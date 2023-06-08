puts "Введите положительное целое число: "

number_array = []
number = count = gets.to_i

while number_array.count < count do
    number_array << number
    number -= 1
end

puts "#{number_array.reverse.to_s}"
puts "Сумма чисел: #{number_array.sum}"