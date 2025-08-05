import 'package:flutter/material.dart';
import 'parent_home_screen.dart';
import 'teacher_home_screen.dart';

class SelectedLogin extends StatefulWidget {
  @override
  _LoginScreenState createState() => _LoginScreenState();
}

class _LoginScreenState extends State<SelectedLogin> {
  final userNameController = TextEditingController();
  final fullNameController = TextEditingController();
  final emailController = TextEditingController();
  final passwordController = TextEditingController();

  String userRole = 'Parent';
  bool isPasswordHidden = true; // 👁️ Add this to toggle password visibility

  @override
  void dispose() {
    userNameController.dispose();
    fullNameController.dispose();
    emailController.dispose();
    passwordController.dispose();
    super.dispose();
  }

  void handleLogin() {
    print('User Name: ${userNameController.text}');
    print('Full Name: ${fullNameController.text}');
    print('Email: ${emailController.text}');
    print('Password: ${passwordController.text}');
    print('Role: $userRole');

    if (userRole == 'Parent') {
      Navigator.push(
        context,
        MaterialPageRoute(builder: (context) => ParentHomeScreen()),
      );
    } else {
      Navigator.push(
        context,
        MaterialPageRoute(builder: (context) => TeacherHomeScreen()),
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('NurseryLink'),
      backgroundColor: Colors.blue,),
      body: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Center(
          child: SingleChildScrollView(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text('Login',
                    style: TextStyle(
                      fontSize: 40.0,
                      fontWeight: FontWeight.bold,
                    )),
                SizedBox(height: 30.0),

                // Role dropdown
                DropdownButtonFormField<String>(
                  value: userRole,
                  decoration: InputDecoration(
                    labelText: 'Select Role',
                    border: OutlineInputBorder(),
                  ),
                  items: ['Parent', 'Teacher'].map((String role) {
                    return DropdownMenuItem<String>(
                      value: role,
                      child: Text(role),
                    );
                  }).toList(),
                  onChanged: (String? value) {
                    setState(() {
                      userRole = value!;
                    });
                  },
                ),
                SizedBox(height: 15.0),

                // User Name field
                TextFormField(
                  controller: userNameController,
                  keyboardType: TextInputType.text,
                  decoration: InputDecoration(
                    labelText: 'User Name',
                    prefixIcon: Icon(Icons.person),
                    border: OutlineInputBorder(),
                  ),
                ),
                SizedBox(height: 15.0),

                // Full Name field
                TextFormField(
                  controller: fullNameController,
                  keyboardType: TextInputType.name,
                  decoration: InputDecoration(
                    labelText: 'Full Name',
                    prefixIcon: Icon(Icons.badge),
                    border: OutlineInputBorder(),
                  ),
                ),
                SizedBox(height: 15.0),

                // Email field
                TextFormField(
                  controller: emailController,
                  keyboardType: TextInputType.emailAddress,
                  decoration: InputDecoration(
                    labelText: 'Email Address',
                    prefixIcon: Icon(Icons.email),
                    border: OutlineInputBorder(),
                  ),
                ),
                SizedBox(height: 15.0),

                // Password field with working eye icon
                TextFormField(
                  controller: passwordController,
                  obscureText: isPasswordHidden,
                  decoration: InputDecoration(
                    labelText: 'Password',
                    prefixIcon: Icon(Icons.lock),
                    suffixIcon: IconButton(
                      icon: Icon(
                        isPasswordHidden
                            ? Icons.visibility
                            : Icons.visibility_off,
                      ),
                      onPressed: () {
                        setState(() {
                          isPasswordHidden = !isPasswordHidden;
                        });
                      },
                    ),
                    border: OutlineInputBorder(),
                  ),
                ),
                SizedBox(height: 20.0),

                // Login button
                Container(
                  width: double.infinity,
                  color: Colors.blue,
                  child: MaterialButton(
                    onPressed: handleLogin,
                    child: Text('LOGIN',
                        style: TextStyle(color: Colors.white)),
                  ),
                ),
                SizedBox(height: 10.0),

                // Register
                Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Text('Don\'t have an account?'),
                    TextButton(
                      onPressed: () {},
                      child: Text('Register Now'),
                    ),
                  ],
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
