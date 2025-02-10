mergeInto(LibraryManager.library, {
  // Fetch words from Firebase
  FetchWordsFromFirebase: function() {
    if (!firebase.apps.length) {
      firebase.initializeApp({
        apiKey: "AIzaSyCu_oqDfhyVmQ9HymU2cuaPPZD2Oi-imPs",
        authDomain: "wordament-16b5a.firebaseapp.com",
        projectId: "wordament-16b5a",
        storageBucket: "wordament-16b5a.firebasestorage.app",
        messagingSenderId: "828815934558",
        appId: "1:828815934558:web:66dab8993514321e4fa0cf"
      });
    }

    var db = firebase.firestore();

    // Fetch words from the wordlist collection
    db.collection("wordlist").doc("Testing").get().then(async (doc) => {
      if (doc.exists) {
        console.log(doc.data());
        var wordsArray = await doc.data(); // Fetch words
        SendMessage('WordHunt', 'OnWordsReceived', JSON.stringify(wordsArray));
      }
    }).catch((error) => {
      console.error("Error fetching words:", error);
    });
  },

  // Fetch game results from Firebase
  FetchGameResultsFromFirebase: function() {
    if (!firebase.apps.length) {
      firebase.initializeApp({
        apiKey: "AIzaSyCu_oqDfhyVmQ9HymU2cuaPPZD2Oi-imPs",
        authDomain: "wordament-16b5a.firebaseapp.com",
        projectId: "wordament-16b5a",
        storageBucket: "wordament-16b5a.firebasestorage.app",
        messagingSenderId: "828815934558",
        appId: "1:828815934558:web:66dab8993514321e4fa0cf"
      });
    }

    var db = firebase.firestore();

    // Fetch game results from the gameResults collection
    db.collection("UserInfo").doc("UserData").get().then(async (doc) => {
      if (doc.exists) {
        console.log(doc.data());
        var gameResults = await doc.data(); // Fetch game results
        SendMessage('WordHunt', 'OnGameResultsReceived', JSON.stringify(gameResults));
      }
    }).catch((error) => {
      console.error("Error fetching game results:", error);
    });
  },

  // Update game result in Firebase
  UpdateGameResultInFirebase: function(modifiedResult) {
    if (!firebase.apps.length) {
      firebase.initializeApp({
        apiKey: "AIzaSyCu_oqDfhyVmQ9HymU2cuaPPZD2Oi-imPs",
        authDomain: "wordament-16b5a.firebaseapp.com",
        projectId: "wordament-16b5a",
        storageBucket: "wordament-16b5a.firebasestorage.app",
        messagingSenderId: "828815934558",
        appId: "1:828815934558:web:66dab8993514321e4fa0cf"
      });
    }

    var db = firebase.firestore();

    // Update the game result document in the "gameResults" collection
    db.collection("UserInfo").doc("UserData").set(modifiedResult) // Using set() to overwrite
      .then(() => {
        console.log("Game result updated successfully!");
        SendMessage('WordHunt', 'OnGameResultUpdated', 'Game result updated');
      })
      .catch((error) => {
        console.error("Error updating game result:", error);
      });
  }
});
