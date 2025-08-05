import 'package:flutter/material.dart';
import 'package:nuresry_link/login_screen.dart';
import 'package:nuresry_link/meal_log_screen.dart';
import 'package:nuresry_link/my_home_page.dart';
import 'package:nuresry_link/parent_meals_log_screen.dart';
import 'package:nuresry_link/selected_login.dart';
import 'package:nuresry_link/toilet_visit_log_screen.dart';
import 'parent_home_screen.dart';
import 'package:nuresry_link/teacher_home_screen.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: SelectedLogin(),

    );
  }
}