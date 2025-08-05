import 'package:flutter/material.dart';

class ParentMealLog {
  final String mealType;
  final String status;
  final DateTime timestamp;

  ParentMealLog({
    required this.mealType,
    required this.status,
    required this.timestamp,
  });
}

class ParentMealsLogScreen extends StatelessWidget {
  final String childName = 'Ahmed Khaled'; // Replace with dynamic name if needed

  // Dummy data for example
  final List<ParentMealLog> logs = [
    ParentMealLog(
      mealType: 'Breakfast',
      status: 'Ate All',
      timestamp: DateTime.now().subtract(Duration(hours: 3)),
    ),
    ParentMealLog(
      mealType: 'Lunch',
      status: 'Ate Some',
      timestamp: DateTime.now().subtract(Duration(hours: 1)),
    ),
    ParentMealLog(
      mealType: 'Snack',
      status: 'Refused',
      timestamp: DateTime.now(),
    ),
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Meal Logs'),
        backgroundColor: Colors.blue,
        leading: IconButton(
          icon: Icon(Icons.menu),
          onPressed: () {
            // Open drawer or menu
          },
        ),
        actions: [
          IconButton(
            icon: Icon(Icons.notifications),
            onPressed: () {
              // Open notifications
            },
          ),
        ],
      ),
      body: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              '$childName\'s Meals Today',
              style: TextStyle(fontSize: 22, fontWeight: FontWeight.bold),
            ),
            SizedBox(height: 15),
            Expanded(
              child: ListView.builder(
                itemCount: logs.length,
                itemBuilder: (context, index) {
                  final log = logs[index];
                  return Card(
                    child: ListTile(
                      leading: Icon(Icons.restaurant_menu, color: Colors.blue),
                      title: Text(log.mealType),
                      subtitle: Text('${log.status} • ${log.timestamp.hour}:${log.timestamp.minute.toString().padLeft(2, '0')}'),
                    ),
                  );
                },
              ),
            )
          ],
        ),
      ),
    );
  }
}
