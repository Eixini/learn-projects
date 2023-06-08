array_size = rand(1..15)
numbers = []

while array_size > numbers.count do
    numbers << rand(0..25)
end

puts "Исходный массив: #{numbers.to_s}"

reverse_numbers = []

for number in numbers do
    reverse_numbers.unshift(number)
end

puts "Новый массив: #{reverse_numbers.to_s}"