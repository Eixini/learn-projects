def circle_area(radius)
    return 3.14 * radius**2
end

puts "Введите радиус круга: "
radius = gets.to_i
puts "Площадь круга: #{circle_area(radius)}"

puts "Введите радиус второго круга: "
radius = gets.to_i
puts "Площадь второго круга: #{circle_area(radius)}"