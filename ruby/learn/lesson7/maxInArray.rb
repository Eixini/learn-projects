puts "Ведите размер массива: "

size = gets.to_i

numbers = []

while numbers.count <= size do
    numbers << rand(0..100)
end

puts numbers.to_s

puts "Максимальный элемент в массиве: #{numbers.max}"