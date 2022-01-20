// Animate 3 electrons orbiting around a nucleus.
// Each electron should follow a path and match
// colors with its respective path.

// Don't use rotate()
// Use vectors and trigonometry

float r;


float theta;
float theta_velocity;
float theta_acceleration;


void setup() {
  size(400, 400);

  r = height * .45;
  theta = 0;
  theta_velocity=0;
  theta_acceleration=0.0001;
}
void draw() {

  drawBackground();

  ///////////////// START YOUR CODE HERE:

  translate(width/2, height/2);


  float x = r * cos(theta); // Polar to Cartesian
  float y = r * sin(theta);

  ellipseMode(CENTER);
  pushMatrix();
  fill(255);
  stroke(128);
  ellipse(83*x/100, y/4, 25, 25);
  popMatrix();

  theta_velocity += theta_acceleration;
  theta += theta_velocity;

  if (theta_velocity >= .05);
  {
    theta_velocity = .05;
  }


  float angle = atan2(y, x);
  float mag = sqrt(x*x + y*y);

  x = mag * cos(angle);
  y = mag * sin(angle);

  angle -= radians(60);

  ellipse(83*x/100, y/4, 25, 25);

  //rotate(PI/3);
  //ellipse(83*x/100, y/4, 25, 25); // Rotate Solution

  //rotate(PI/3);
  //ellipse(83*x/100, y/4, 25, 25);


  println(theta_velocity);

  ///////////////// END YOUR CODE HERE
}
void drawBackground() {
  // The white Circle
  background(0);
  noStroke();
  fill(255);
  ellipse(200, 200, 50, 50);
  noFill();
  strokeWeight(5);

  pushMatrix();
  // The Red Circle
  translate(200, 200);
  stroke(255, 100, 100);
  ellipse(0, 0, 300, 100);
  popMatrix();

  pushMatrix();
  // The Green Circle
  translate(200, 200);
  rotate(PI/1.5);
  stroke(100, 255, 100);
  ellipse(0, 0, 300, 100);
  popMatrix();

  pushMatrix();
  // The Blue Circle
  translate(200, 200);
  rotate(2*PI/1.5);
  stroke(100, 100, 255);
  ellipse(0, 0, 300, 100);
  popMatrix();
}
