TRIANGLES

All triangle sides will add up to 180 degrees (ex: right triangle with a 90 degree and two 45 degree angles).
Only one angle can be 90 degrees or greater. (a + b + c = 180 degrees)
Triangle Inequality Theorem: any two sides must be equal or greater than the third side (this validates a triangle).

Triangles can be defined by two things:
	- angles
		- right angles (one side = 90 degrees)
			- special: 45-45-90 (legs = x, hypotenuse = x * square root of 2)
			- special: 30-60-90 (leg 1 = x, leg 2 = x * square root of 3, hypotenuse = 2x)
			- all: satisfies the pythagorean theorem (a^2 + b^2 = c^2, with c being the longest side)
		- acute (all angles < 90 degrees, a^2 + b^2 > c^2, with c being the longest side)
		- obtuse (one side > 90 degrees < 180 degrees, a^2 + b^2 < c^2, with c being the longest side)
	- sides
		- scalene: all sides are of differing lengths (no equal sides)
		- isosceles: two equal sides (w/two identical angles facing each other)
		- equilateral: all equal sides (60 degrees each, which results in all angles identical)
		
		
Hypotenuse: the longest side of a right triangle, the side opposite of the right angle 
	- (a^2 + b^2 = c^2) or (c = the square root of (a^2 + b^2))
	
Possibilities:
	scalene and right
	scalene and acute
	scalene and obtuse
	isosceles and right
	isosceles and acute
	isosceles and obtuse
	equilateral and acute
	
Plan:
1. isolate easiest to figure triangles that don't take calculation for angles
	- check for invalid triangle
	- check for all equal sides (equilateral and acute)
		- no need to use pythagorean theorem
		- no need to use degrees formula (all corners are 60 degrees)
2. check for two equal sides
	- use pythagorean theorem to check for right, acute, or obtuse
	- if it's a right triangle, then you have a 90-45-45, else use degree formula to determine corner degrees (see: Optional)
		- two corners should be the same
3. check for no equal sides
	- use pythagorean theorem to check for right, acute, or obtuse
	- use degree formula to determine corner degrees (see: Optional)

Optional:
1. use cosine to find the angles from knowing all three sides:
	- see the formulas below
2. use Math.Acos() to get the degrees

Example triangle:
	side a: 3
	side b: 4
	side c: 5
	
	cosA = (b^2 + c^2 - a^2) / (2bc) = (16 + 25 - 9) / 40 = 32/40 = 4/5 or .8 --> arccos of .8 is 36.87 degrees
	cosB = (a^2 + c^2 - b^2) / (2ac) = (9 + 25 - 16) / 30 = 18/30 = 3/5 or .6 --> arccos of .6 is 53.13 degrees
	cosC = (a^2 + b^2 - c^2) / (2ab) = (9 + 16 - 25) / 24 = 0/24 = 0 --> arccos of 0 is 90 degrees
	
	36.87 + 53.13 + 90 = 180 (scalene and right triangle)