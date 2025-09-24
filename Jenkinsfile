pipeline {
    agent any

    environment {
        // Slack token stored in Jenkins Credentials (kind: Secret text)
        SLACK_TOKEN = credentials('slack-token-id')
    }

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/kwamasco23/MandMdirectExampleProject.git'
            }
        }

        stage('Restore') {
            steps {
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build --configuration Release --no-restore'
            }
        }

        stage('Test') {
            steps {
                bat 'dotnet test --no-build --configuration Release --verbosity normal'
            }
        }
    }

    post {
        success {
            slackSend(
                channel: '#general',
                color: 'good',
                message: "SpecFlow CI Pipeline SUCCESS for branch ${env.BRANCH_NAME}",
                tokenCredentialId: 'slack-token-id'
            )
        }

        failure {
            slackSend(
                channel: '#general',
                color: 'danger',
                message: "SpecFlow CI Pipeline FAILED for branch ${env.BRANCH_NAME}",
                tokenCredentialId: 'slack-token-id'
            )
        }
    }
}
